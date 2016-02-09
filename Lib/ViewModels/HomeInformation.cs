using Lib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class HomeInformation
    {
        public int DeviceCount { get; set; }
        public int ApplicationCount { get; set; }
        public int CrashCount { get; set; }

        public List<tblApplications> Applications { get; set; }
        public List<tblCrashReports> CrashReports { get; set; }
        public List<tblDevices> Devices { get; set; }
    }
}
