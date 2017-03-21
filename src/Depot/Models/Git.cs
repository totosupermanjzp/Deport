using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depot.Models
{
    public class Git
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GitID { get; set; }          //仓库ID
        public string Title { get; set; }       //仓库类型
        public string position { get; set; }    //仓库楼层

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
