//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lib.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomers
    {
        public tblCustomers()
        {
            this.tblApplications = new HashSet<tblApplications>();
        }
    
        public int customerId { get; set; }
        public string contactPerson { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
    
        public virtual ICollection<tblApplications> tblApplications { get; set; }
    }
}
