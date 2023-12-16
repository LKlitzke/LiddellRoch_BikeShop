using LiddellRoch.Models;
using LiddellRoch.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LiddellRoch.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<RadialBarChartVm> GetTotalComprasChartData();
        Task<RadialBarChartVm> GetRegistrosUsuariosChartData();
        Task<RadialBarChartVm> GetLucrosChartData();
        Task<PieChartVm> GetComprasCategoriasPieChartData();
        Task<LineChartVm> GetUsersAndComprasLineChartData();
    }
}