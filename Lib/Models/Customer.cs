using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
     [Serializable]
    public class Customer
    {

        public int customerId { get; set; }
        public string contactPerson { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }

        public virtual List<Application> tblApplications { get; set; }
    }
}
