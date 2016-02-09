using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Device
    {

        public int deviceId { get; set; }
        public string OSVersion { get; set; }
        public string AppVersion { get; set; }
        public string UniqueId { get; set; }

        public System.DateTime InsertDate { get; set; }
        public System.DateTime LastCheckinDate { get; set; }
        public int AppID { get; set; }

        public Application Application { get; set; }
        public virtual ICollection<CrashReport> tblCrashReports { get; set; }
    }
}
