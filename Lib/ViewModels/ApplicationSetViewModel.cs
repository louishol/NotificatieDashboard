using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    [Serializable]
    public class ApplicationSetViewModel
    {
        public String name { get; set; }
        public int applicationId { get; set; }
        public string version { get; set; }
    }
}
