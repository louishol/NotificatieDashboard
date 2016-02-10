using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
     [Serializable]
    public class Message
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public int tblApplications_applicationId { get; set; }
        public int tbLanguageCodes_languageId { get; set; }

        public virtual Application tblApplications { get; set; }
        public virtual LanguageCode tblLanguageCodes { get; set; }
    }
}
