using AutoMapper;
using Lib.Models;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class Applications
    {
        public static List<Application> Get()
        {
       
            using (var db = new dbContainer())
            {
                var models = from i in db.tblApplications 
                             select i; 
               return Mapper.Map<List<tblApplications>, List<Application>>(models.ToList());
            }
        }

        public static List<PopularViewModel> GetPopularApps(int limit)
        {

            using (var db = new dbContainer())
            {
                var models = (from a in db.tblApplications
                              join d in db.tblDevices on a.applicationId equals d.tblApplications_applicationId
                              group a by new {a.applicationId, a.name} into popular
                              select new PopularViewModel
                              {
                                  applicationId = popular.Key.applicationId,
                                  applicationName = popular.Key.name,
                                  devices = popular.Count()
                              });

                return models.Take(limit).ToList();
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
        public static Application AddMessage(MessageViewModel VMMessage)
        {
            using (var db = new dbContainer())
            {
                var application = db.tblApplications.Find(VMMessage.tblApplications_applicationId);
                tblMessages msg = Mapper.Map<MessageViewModel, tblMessages>(VMMessage);
                application.tblMessages.Add(msg);
                db.SaveChanges();
                return Mapper.Map<tblApplications, Application>(application);
            }
        }
        public static Counter GetProgramStatistics()
        {
            using (var db = new dbContainer())
            {
                var models = from c in db.tblCounts
                             select c;
                //result
                tblCounts result = models.FirstOrDefault();
                return Mapper.Map<tblCounts, Counter>(result);
            }
        }
    }
}
