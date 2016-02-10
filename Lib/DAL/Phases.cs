using AutoMapper;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class Phases
    {
        public static List<Phase> Get()
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblPhases
                             select i;
                return Mapper.Map<List<tblPhases>, List<Phase>>(models.ToList());
            }
        }
    }
}
