//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class tblApplications
    {
        public tblApplications()
        {
            this.tblDevices = new HashSet<tblDevices>();
            this.tblMessages = new HashSet<tblMessages>();
        }
    
        public int applicationId { get; set; }
        [DisplayName("Naam")]
        public string name { get; set; }
          [DisplayName("Bericht herhalen")]
        public bool repeatable { get; set; }
          [DisplayName("Versie")]
        public string version { get; set; }
          [DisplayName("Applicatie identifier")]
        public string uniqueId { get; set; }
          [DisplayName("Update URL")]
        public string url { get; set; }
          [DisplayName("Bericht herhalen vanaf")]
        public string repeatVersion { get; set; }
        [DisplayName("Besturingssyteem")]
        public int tblOperatingSystems_operatingSystemId { get; set; }
        [DisplayName("Fase")]
        public int tblPhases_phaseId { get; set; }
        [DisplayName("Klant")]
        public int tblCustomers_customerId { get; set; }
    
        public virtual tblOperatingSystems tblOperatingSystems { get; set; }
        public virtual tblCustomers tblCustomers { get; set; }
        public virtual tblPhases tblPhases { get; set; }
        public virtual ICollection<tblDevices> tblDevices { get; set; }
        public virtual ICollection<tblMessages> tblMessages { get; set; }
    }
}
