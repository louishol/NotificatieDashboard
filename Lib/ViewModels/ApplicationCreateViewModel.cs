using Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class ApplicationCreateViewModel
    {


        public int applicationId { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        [Display(Name = "Naam")]
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

        [Required(ErrorMessage = "Besturingssysteem vanaf is verplicht")]
        [Display(Name = "Besturingssysteem")]
        public int tblOperatingSystems_operatingSystemId { get; set; }
        [Required(ErrorMessage = "Fase vanaf is verplicht")]
        [Display(Name = "Fase")]
        public int tblPhases_phaseId { get; set; }
        [Required(ErrorMessage = "Klant vanaf is verplicht")]
        [Display(Name = "Klant")]
        public int tblCustomers_customerId { get; set; }

        public IEnumerable<Phase> Phases { get; set; }
        public IEnumerable<Lib.Models.OperatingSystem> OperatingSystems { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
