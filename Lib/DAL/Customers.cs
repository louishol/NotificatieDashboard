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
        public static List<Customer> GetPagination(int itemPerPage = 0, int pageNumber = 1)
        {

            using (var db = new dbContainer())
            {
                var models = from i in db.tblCustomers
                             select i;
                return Mapper.Map<List<tblCustomers>, List<Customer>>(models.OrderBy(m => m.customerId).Skip(itemPerPage * (pageNumber - 1)).Take(itemPerPage).ToList());
            }
        }
        public static void Create(Customer model)
        {
            using (var db = new dbContainer())
            {
                var customer = Mapper.Map<Customer, tblCustomers>(model);
                customer.dateCreated = DateTime.Now;
                db.tblCustomers.Add(customer);
                db.SaveChanges();

            }
        }
        public static void Edit(Customer model)
        {
            using (var db = new dbContainer())
            {
                var customer = Mapper.Map<Customer, tblCustomers>(model);
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static Customer Delete(int customerId)
        {
            using (var db = new dbContainer())
            {
                var dbCustomer = (from c in db.tblCustomers where c.customerId == customerId select c).FirstOrDefault();
                var customer = Mapper.Map<tblCustomers, Customer>(dbCustomer);
                if (dbCustomer != null)
                {
                    db.tblCustomers.Remove(dbCustomer);
                    db.SaveChanges();
                }
                return customer;
            }
        }
        public static Customer GetDetails(int? id)
        {
            if (id.HasValue)
            {
                using (var db = new dbContainer())
                {
                    var models = from c in db.tblCustomers
                                 where c.customerId == id
                                 select c;
                    var result = models.FirstOrDefault();
                    return Mapper.Map<tblCustomers, Customer>(result);
                }
            }
            return null;
        }
    }
}
