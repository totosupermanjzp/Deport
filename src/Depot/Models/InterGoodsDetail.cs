using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class InterGoodsDetail
    {
        public int ID { get; set; }
        public int interBookID { get; set; }
        public string goodsName { get; set; }
        public string saleID { get; set; }
        public string salemanName { get; set; }
        public int number { get; set; }
    }
}
