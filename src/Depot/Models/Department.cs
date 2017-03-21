using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }               //部门ID
        public string type { get; set; }                    //部门类型
        public string power { get; set; }                   //部门权利
        public int account { get; set; }                    //人数
    }
}
