using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class Name
    {
        public int ID { get; set; }                     //货物ID
        public string Goods { get; set; }               //货物名称
        public int GoodsRFID { get; set; }              //RFID编码
        public int number { get; set; }                 //货物数量
        public DateTime EnrollmentDate { get; set; }    //货物进货的时间
        public string InterPerson { get; set; }         //进货人
        public bool isOut { get; set; }                 //货物是否出货
        public string location { get; set; }            //出货地址
        public string suplierID { get; set; }           //供应商ID
        public double price { get; set; }               //单价

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
