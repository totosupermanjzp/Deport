using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public class DataDetail
    {
        public int ID { get; set; }
        public int DataID { get; set; }
        public string Goodsname { get; set; }
        public double butprice { get; set; }
        public int buynumber { get; set; }
        public double saleprice { get; set; }
        public int salenumber { get; set; }
        public double TotalSaleMoney { get; set; }

    }
}
