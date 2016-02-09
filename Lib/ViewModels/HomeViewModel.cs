using Lib.DAL;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class HomeViewModel
    {
        public int DeviceCount { get; set; }
        public int ApplicationCount { get; set; }
        public int CrashCount { get; set; }

        public List<Application> Applications { get; set; }
        public List<CrashReport> CrashReports { get; set; }
        public List<Device> Devices { get; set; }
        public List<Customer> Customers { get; set; }
        public List<OSViewModel> OSStatistics { get; set; }
        public List<PopularViewModel> Popular { get; set; }
    }
}
