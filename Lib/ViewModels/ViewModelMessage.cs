using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class ViewModelMessage
    {
        public int tblApplications_applicationId { get; set; }
        public String message { get; set; }
        public int tbLanguageCodes_languageId { get; set; }

    }
}
