using AutoMapper;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class OperatingSystems
    {
        public static List<Lib.Models.OperatingSystem> Get()
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblOperatingSystems
                             select i;
                return Mapper.Map<List<tblOperatingSystems>, List<Lib.Models.OperatingSystem>>(models.ToList());
            }
        }
        public static List<OSViewModel> GetStatistics()
        {
          //  select tblOperatingSystems.name, COUNT(*) as counter from tblApplications JOIN tblOperatingSystems on tblApplications.tblOperatingSystems_operatingSystemId = tblOperatingSystems.operatingSystemId group by tblOperatingSystems.name

            using (var db = new dbContainer())
            {
                var models = (from a in db.tblApplications
                              join d in db.tblOperatingSystems on a.tblOperatingSystems_operatingSystemId equals d.operatingSystemId
                              group a by d.name into OS
                              select new OSViewModel
                              {
                                 name = OS.Key,
                                 counter = OS.Count()
                              });

                return models.ToList(); 
        
            }
        }
    }
}
