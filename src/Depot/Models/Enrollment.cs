using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public enum Address
    {
        A,B,C,D,E
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int GitID { get; set; }          //仓库ID
        public int NameID { get; set; }         //货物ID
        public Address? Address { get; set; }   //地址

        public Git Git { get; set; }            //仓库
        public Name Name { get; set; }          //货物
    }
}
