using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
     [Serializable]
    public class CrashReport
    {
        public int crashReportId { get; set; }
        public string report { get; set; }
        public System.DateTime date { get; set; }
        public int tblDevices_deviceId { get; set; }

        public Device tblDevices { get; set; }
    }
}
