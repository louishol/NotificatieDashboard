using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public List<Application> Applications { get; set; }
    }
}
