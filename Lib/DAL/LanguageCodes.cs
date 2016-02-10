using AutoMapper;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class LanguageCodes
    {
        public static List<LanguageCode> Get()
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblLanguageCodes
                             select i;
                return Mapper.Map<List<tblLanguageCodes>, List<LanguageCode>>(models.ToList());
            }
        }
    }
}
