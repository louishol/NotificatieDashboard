using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class PopularApp
    {
        public int applicationId { get; set; }
        public String name { get; set; }
        public int devices { get; set; }
    }
}