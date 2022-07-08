using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SearchLog
    {
        public int Id { get; set; }
        public string InputText { get; set; }
        public string TranslatedText { get; set; }
        public string UserName { get; set; }
        public string TranslationType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
