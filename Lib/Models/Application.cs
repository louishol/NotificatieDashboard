using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    [Serializable]
    public class Application
    {
        public int applicationId { get; set; }
        public string Name { get; set; }
        public bool Repeatable { get; set; }
        public string Version { get; set; }
        public string UniqueId { get; set; }
        public string Url { get; set; }
        public string RepeatVersion { get; set; }

        public int OperatingSystemId { get; set; }
        public int PhaseId { get; set; }
        public int CustomerId { get; set; }


        public OperatingSystem OperatingSystems { get; set; }
        public Customer Customers { get; set; }
      //  public virtual tblPhases tblPhases { get; set; }


    //    public List<> tblDevices { get; set; }
   //     public List<> tblMessages { get; set; }
    }
}
