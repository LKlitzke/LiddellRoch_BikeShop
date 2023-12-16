using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTotalComprasChartData()
        {
            return Json(await _dashboardService.GetTotalComprasChartData());
        }

        public async Task<IActionResult> GetRegistrosUsuariosChartData()
        {
            return Json(await _dashboardService.GetRegistrosUsuariosChartData());
        }

        public async Task<IActionResult> GetLucrosChartData()
        {
            return Json(await _dashboardService.GetLucrosChartData());
        }

        public async Task<IActionResult> GetComprasCategoriasPieChartData()
        {
            return Json(await _dashboardService.GetComprasCategoriasPieChartData());
        }

        public async Task<IActionResult> GetUsersAndComprasLineChartData()
        {
            return Json(await _dashboardService.GetUsersAndComprasLineChartData());
        }
    }
}
