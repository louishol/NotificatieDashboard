using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
     [Serializable]
    public class Device
    {

        public int deviceId { get; set; }
        public string operatingSystemVersion { get; set; }
        public string appVersion { get; set; }
        public string uniqueId { get; set; }
        public System.DateTime insertDate { get; set; }
        public System.DateTime lastCheckinDate { get; set; }
        public int tblApplications_applicationId { get; set; }

        public Application tblApplications { get; set; }
        public ICollection<CrashReport> tblCrashReports { get; set; }
    }
}
