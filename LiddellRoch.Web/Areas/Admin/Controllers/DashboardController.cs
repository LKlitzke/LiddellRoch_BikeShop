using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        static int mesAnterior = DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1;
        readonly DateTime mesInicialAnterior = new DateTime(DateTime.Now.Year, mesAnterior, 1);
        readonly DateTime mesInicialAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTotalComprasChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u => 
                u.StatusPedido != SD.StatusCancelled 
                || u.StatusPedido != SD.StatusPending);

            var countComprasMesAtual = totalCompras.Count(u => u.DataPedido >= mesInicialAtual && u.DataPedido <= DateTime.Now);
            var countComprasMesAnterior = totalCompras.Count(u => u.DataPedido >= mesInicialAnterior && u.DataPedido <= mesInicialAtual);

            var radialBarChartVm = GetRadialChartDataModel(totalCompras.Count(), countComprasMesAtual, countComprasMesAnterior);
            return Json(radialBarChartVm);
        }

        public async Task<IActionResult> GetRegistrosUsuariosChartData()
        {
            var totalUsers = _unitOfWork.ApplicationUser.GetAll();

            var countRegistrosMesAtual = totalUsers.Count(u => u.CriadoEm  >= mesInicialAtual && u.CriadoEm <= DateTime.Now);
            var countRegistrosMesAnterior = totalUsers.Count(u => u.CriadoEm >= mesInicialAnterior && u.CriadoEm <= mesInicialAtual);

            var radialBarChartVm = GetRadialChartDataModel(totalUsers.Count(), countRegistrosMesAtual, countRegistrosMesAnterior);
            return Json(radialBarChartVm);
        }

        public async Task<IActionResult> GetLucrosChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u =>
                u.StatusPedido != SD.StatusCancelled
                || u.StatusPedido != SD.StatusPending);

            var totalLucro = Convert.ToInt32(totalCompras.Sum(e => e.TotalPedido));

            var totalLucroMesAtual = Decimal.ToDouble(totalCompras.Where(u => u.DataPedido >= mesInicialAtual && u.DataPedido <= DateTime.Now).Sum(e => e.TotalPedido));
            var totalLucroAnterior = Decimal.ToDouble(totalCompras.Where(u => u.DataPedido >= mesInicialAnterior && u.DataPedido <= mesInicialAtual).Sum(e => e.TotalPedido));

            var radialBarChartVm = GetRadialChartDataModel(totalLucro, totalLucroMesAtual, totalLucroAnterior);
            return Json(radialBarChartVm);
        }

        public async Task<IActionResult> GetComprasCategoriasPieChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u =>
                u.DataPedido >= DateTime.Now.AddDays(-30) 
                && (u.StatusPedido != SD.StatusCancelled || u.StatusPedido != SD.StatusPending));

            /* MODIFICAR NOMES!!!! */
            var compraUnica = totalCompras.GroupBy(b => b.ApplicationUserId).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            int comprasUnicasPorNovoUsuario = compraUnica.Count();
            int comprasUnicasPorUsuario = totalCompras.Count() - comprasUnicasPorNovoUsuario;

            PieChartVm pieChartVm = new()
            {
                Labels = new string[] { "New Customer Compras", "Returning Customer Compras" },
                Series = new decimal[] { comprasUnicasPorNovoUsuario, comprasUnicasPorUsuario }
            };

            return Json(pieChartVm);
        }


        private static RadialBarChartVm GetRadialChartDataModel(int totalCount, double countMesAtual, double countMesAnterior)
        {

            RadialBarChartVm radialBarChartVm = new();

            int increaseRate = 100;

            if (countMesAnterior != 0)
            {
                increaseRate = Convert.ToInt32((countMesAtual - countMesAnterior) / countMesAnterior * 100);
            }

            radialBarChartVm.TotalCount = totalCount;
            radialBarChartVm.CountInCurrentMonth = Convert.ToInt32(countMesAtual);
            radialBarChartVm.HasRatioIncreased = countMesAtual > countMesAnterior;
            radialBarChartVm.Series = new int[] { increaseRate };

            return radialBarChartVm;
        }
    }
}
