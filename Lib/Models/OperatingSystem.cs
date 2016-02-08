using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{

    public class OperatingSystem
    {

        public int operatingSystemId { get; set; }
        public string name { get; set; }
        public List<Application> tblApplications { get; set; }
    }
}
