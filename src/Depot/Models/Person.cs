using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Models
{
    public enum Power{
        G,              //管理人员拥有最高权限
        H,              //后勤组，可以出库入库，无权删改修改货物
        S,              //供应商，只能查看订单号
        X               //快递小哥，只能查看仓库货物情况
    }
    public class Person
    {
        public int PersonID { get; set; }                          //人事ID
        public string PersonName { get; set; }                  //名字
        public string DepartmentId { get; set; }                //属于那个部门
        public string PersonManage { get; set; }                //地位
        public Power? Power { get; set; }                       //权限
    }
}
