using AutoMapper;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class CrashReports
    {
        public static List<CrashReport> Get()
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblCrashReports
                             select i;
                return Mapper.Map<List<tblCrashReports>, List<CrashReport>>(models.ToList());
            }
        }

        public static int GetCount()
        {

            using (var db = new dbContainer())
            {
                var count = from i in db.tblCrashReports
                            select i;
                return count.Count();
            }
        }
    }
}
