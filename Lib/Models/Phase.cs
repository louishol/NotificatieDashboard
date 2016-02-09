using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Phase
    {
        public int phaseId { get; set; }
        public string Name { get; set; }

        public virtual List<Application> Applications { get; set; }
    }
}
