using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
     [Serializable]
    public class Phase
    {
        public int phaseId { get; set; }
        public string name { get; set; }

        public List<Application> tblApplications { get; set; }
    }
}
