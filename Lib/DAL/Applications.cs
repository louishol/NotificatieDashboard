using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class Applications
    {
        public static List<tblApplications> Get()
        {
       
            using (var db = new dbContainer())
            {
                var models = from i in db.tblApplications 
                             select i;
                return models.ToList();
            }
        }
    }
}
