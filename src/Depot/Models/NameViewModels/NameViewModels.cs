using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models.NameViewModels
{
    public class NameViewModels
    {
        [DataType(DataType.Date)]
        public string name { get; set; }
        public int number { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Address { get; set; }
        public bool IsOut { get; set; }
        public int supplier { get; set; }

    }
}
