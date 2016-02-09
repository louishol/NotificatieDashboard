using AutoMapper;
using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL
{
    public class Customers
    {
        public static List<Customer> Get()
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblCustomers
                             select i;
                return Mapper.Map<List<tblCustomers>, List<Customer>>(models.ToList());
            }
        }

    }
}
