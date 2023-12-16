using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        static int mesAnterior = DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1;
        readonly DateTime mesInicialAnterior = new(DateTime.Now.Year, mesAnterior, 1);
        readonly DateTime mesInicialAtual = new(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PieChartVm> GetComprasCategoriasPieChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u =>
                u.DataPedido >= DateTime.Now.AddDays(-30)
                && (u.StatusPedido != SD.StatusCancelled || u.StatusPedido != SD.StatusPending));

            /* MODIFICAR NOMES!!!! */
            var compraUnica = totalCompras.GroupBy(b => b.ApplicationUserId).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            int comprasUnicasPorNovoUsuario = compraUnica.Count;
            int comprasUnicasPorUsuario = totalCompras.Count() - comprasUnicasPorNovoUsuario;

            PieChartVm pieChartVm = new()
            {
                Labels = new string[] { "New Customer Compras", "Returning Customer Compras" },
                Series = new decimal[] { comprasUnicasPorNovoUsuario, comprasUnicasPorUsuario }
            };

            return pieChartVm;
        }

        public async Task<RadialBarChartVm> GetLucrosChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u =>
                u.StatusPedido != SD.StatusCancelled
                || u.StatusPedido != SD.StatusPending);

            var totalLucro = Convert.ToInt32(totalCompras.Sum(e => e.TotalPedido));

            var totalLucroMesAtual = Decimal.ToDouble(totalCompras.Where(u => u.DataPedido >= mesInicialAtual && u.DataPedido <= DateTime.Now).Sum(e => e.TotalPedido));
            var totalLucroAnterior = Decimal.ToDouble(totalCompras.Where(u => u.DataPedido >= mesInicialAnterior && u.DataPedido <= mesInicialAtual).Sum(e => e.TotalPedido));

            return GetRadialChartDataModel(totalLucro, totalLucroMesAtual, totalLucroAnterior);
        }

        public async Task<RadialBarChartVm> GetRegistrosUsuariosChartData()
        {
            var totalUsers = _unitOfWork.ApplicationUser.GetAll();

            var countRegistrosMesAtual = totalUsers.Count(u => u.CriadoEm >= mesInicialAtual && u.CriadoEm <= DateTime.Now);
            var countRegistrosMesAnterior = totalUsers.Count(u => u.CriadoEm >= mesInicialAnterior && u.CriadoEm <= mesInicialAtual);

            return GetRadialChartDataModel(totalUsers.Count(), countRegistrosMesAtual, countRegistrosMesAnterior);
        }

        public async Task<RadialBarChartVm> GetTotalComprasChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader.GetAll(u =>
                u.StatusPedido != SD.StatusCancelled
                || u.StatusPedido != SD.StatusPending);

            var countComprasMesAtual = totalCompras.Count(u => u.DataPedido >= mesInicialAtual && u.DataPedido <= DateTime.Now);
            var countComprasMesAnterior = totalCompras.Count(u => u.DataPedido >= mesInicialAnterior && u.DataPedido <= mesInicialAtual);

            return GetRadialChartDataModel(totalCompras.Count(), countComprasMesAtual, countComprasMesAnterior);
        }

        public async Task<LineChartVm> GetUsersAndComprasLineChartData()
        {
            var totalCompras = _unitOfWork.PedidoHeader
                .GetAll(u => u.DataPedido >= DateTime.Now.AddDays(-30) && u.DataPedido.Date <= DateTime.Now)
                .GroupBy(b => b.DataPedido.Date)
                .Select(u => new { Datetime = u.Key, NewComprasCount = u.Count() });

            var totalUsers = _unitOfWork.ApplicationUser
                .GetAll(u => u.CriadoEm >= DateTime.Now.AddDays(-30) && u.CriadoEm.Date <= DateTime.Now)
                .GroupBy(b => b.CriadoEm.Date)
                .Select(u => new { Datetime = u.Key, NewUsersCount = u.Count() });


            var leftJoin = totalCompras.GroupJoin(totalUsers, compra => compra.Datetime, user => user.Datetime,
                (compra, user) => new
                {
                    compra.Datetime,
                    compra.NewComprasCount,
                    NewUsersCount = user.Select(x => x.NewUsersCount).FirstOrDefault()
                });


            var rightJoin = totalUsers.GroupJoin(totalCompras, user => user.Datetime, compra => compra.Datetime,
                (user, compra) => new
                {
                    user.Datetime,
                    NewComprasCount = compra.Select(x => x.NewComprasCount).FirstOrDefault(),
                    user.NewUsersCount
                });

            var mergedData = leftJoin.Union(rightJoin).OrderBy(x => x.Datetime).ToList();

            var newCompraData = mergedData.Select(x => x.NewComprasCount).ToArray();
            var newUserData = mergedData.Select(x => x.NewUsersCount).ToArray();
            var categories = mergedData.Select(x => x.Datetime.ToString("dd/MM/yyyy")).ToArray();

            List<ChartData> chartDataList = new()
            {
                new ChartData
                {
                    Name = "Novas Compras",
                    Data = newCompraData
                },
                new ChartData
                {
                    Name = "Novos Usuários",
                    Data = newUserData
                },
            };

            LineChartVm LineChartVm = new()
            {
                Categories = categories,
                Series = chartDataList
            };

            return LineChartVm;
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
