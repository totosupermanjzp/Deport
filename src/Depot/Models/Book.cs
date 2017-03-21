using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class Book
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string bookName { get; set; }
        public int nameID { get; set; }
        public int namenumber { get; set; }
        public string location { get; set; }
    }
}
