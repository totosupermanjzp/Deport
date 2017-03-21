using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class OutGoods
    {
        public int ID { get; set; }                     //货物编号
        public string Goods { get; set; }               //货物名称
        public int number { get; set; }                 //货物数量
        public DateTime EnrollmentDate{get;set;}        //出货时间
        public string location { get; set; }            //出货地点
        public double price { get; set; }               //出货价格
        public string personname { get; set; }          //出货人
    }
}
