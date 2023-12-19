using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Models.ViewModels
{
    public class RadialBarChartVm
    {
        public double TotalCount { get; set; }
        public double CountInCurrentMonth { get; set; }
        public decimal IncreaseRate { get; set; }
        public bool HasRatioIncreased { get; set; }
        public int[] Series {  get; set; }
    }
}
