using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class LanguageCode
    {
        public int languageId { get; set; }
        public string name { get; set; }

        public ICollection<Message> tblMessages { get; set; }
    }
}
