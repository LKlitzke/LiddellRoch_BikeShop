using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models.ViewModels
{
    public class PieChartVm
    {
        public decimal[] Series { get; set; }
        public string[] Labels { get; set; }
    }
}
