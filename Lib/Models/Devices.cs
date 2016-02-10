using AutoMapper;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
     [Serializable]
    public class Devices
    {
        public static List<Device> Get()
        {
            using (var db = new dbContainer())
            {
                var models = from i in db.tblDevices
                             select i;
               return Mapper.Map<List<tblDevices>, List<Device>>(models.ToList());;
            }
        }
        public static int GetCount()
        {
            using (var db = new dbContainer())
            {
                var models = from i in db.tblDevices
                             select i;
                return models.Count();
            }
        }
        public static List<Device> GetDevicesInRecentDate(int daysAgo)
        {
            daysAgo = daysAgo * -1;
            using (var db = new dbContainer())
            {
                var dateweekago = DateTime.Now.AddDays(-7);
                var models = from d in db.tblDevices
                             where d.insertDate > dateweekago
                             select d;
                return Mapper.Map<List<tblDevices>, List<Device>>(models.ToList()); ;
            }
        }
    }
}
