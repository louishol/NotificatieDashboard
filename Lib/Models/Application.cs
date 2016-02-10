using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    [Serializable]
    public class Application
    {
       // public int applicationId { get; set; }
       // public string Name { get; set; }
       // public bool Repeatable { get; set; }
       // public string Version { get; set; }
       // public string UniqueId { get; set; }
       // public string Url { get; set; }
       // public string RepeatVersion { get; set; }

       // public int OperatingSystemId { get; set; }
       // public int PhaseId { get; set; }
       // public int CustomerId { get; set; }


       // public OperatingSystem OperatingSystem { get; set; }
       // public Customer Customer { get; set; }
       // public Phase Phase { get; set; }


       //public List<Device> Devices { get; set; }
       //public List<Message> Message { get; set; }

        public int applicationId { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        [Display(Name="Naam")]
        public string name { get; set; }
        [Required(ErrorMessage = "Herhaaldelijk is verplicht")]
        [Display(Name = "Herhaaldelijk")]
        public bool repeatable { get; set; }
        [Required(ErrorMessage = "Versie is verplicht")]
        [Display(Name = "Versie")]
        public string version { get; set; }
        [Required(ErrorMessage = "Unieke ID is verplicht")]
        [Display(Name = "Unieke ID")]
        public string uniqueId { get; set; }
        [Required(ErrorMessage = "Update URL is verplicht")]
        [Display(Name = "Update URL")]
        public string url { get; set; }
        [Required(ErrorMessage = "Herhalen vanaf is verplicht")]
        [Display(Name = "Herhalen vanaf")]
        public string repeatVersion { get; set; }

        public int tblOperatingSystems_operatingSystemId { get; set; }
        public int tblPhases_phaseId { get; set; }
        public int tblCustomers_customerId { get; set; }

        public  OperatingSystem tblOperatingSystems { get; set; }
        public  Customer tblCustomers { get; set; }
        public  Phase tblPhases { get; set; }
        public  ICollection<Device> tblDevices { get; set; }
        public  ICollection<Message> tblMessages { get; set; }
    }
}
