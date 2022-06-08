using LibraryManager.Constance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DataAccess.Dtos
{
    public class RegisterBookDto: BaseModels
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublicationYear { get; set; }
    }
}
