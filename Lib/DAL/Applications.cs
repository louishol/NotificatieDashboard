using AutoMapper;
using Lib.Models;
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

        public static int GetCount()
        {

            using (var db = new dbContainer())
            {
                var count = from i in db.tblApplications
                             select i;
                return count.Count();
            }
        }
        public static Application GetDetails(int id = 0)
        {
            using (var db = new dbContainer())
            {
                var models = from a in db.tblApplications
                             where a.applicationId == id
                             select a;
                //Result
                tblApplications result = models.FirstOrDefault();
                //mappen
                return Mapper.Map<tblApplications, Application>(result);

            }
        }
    }
}
