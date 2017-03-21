using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Depot.Data;

namespace Depot.Models
{
    public class DbInitializer
    {
        public static void Initialize(NameContext Context)
        {
            Context.Database.EnsureCreated();
            if(Context.Names.Any())
            {
                return;
            }
            var names = new Name[]
            {
                new Name {Goods = "防盗门",number = 250,   EnrollmentDate = DateTime.Parse("2017-01-01"),isOut = true, location="北京" , suplierID = "001", price = 22.9,GoodsRFID = 20012},
                new Name {Goods = "键盘",  number = 199,   EnrollmentDate = DateTime.Parse("2016-12-02"),isOut = false,location="哈尔滨",suplierID = "002", price = 11.1,GoodsRFID = 20013},
                new Name {Goods = "大理石",number = 700,   EnrollmentDate = DateTime.Parse("2015-10-10"),isOut = false,location="深圳",  suplierID = "005", price = 7.8,GoodsRFID = 20014},
                new Name {Goods = "导航",  number = 200,   EnrollmentDate = DateTime.Parse("2017-02-01"),isOut = false,location="海南",  suplierID = "004", price = 9.5,GoodsRFID = 20015},
                new Name {Goods = "表",    number = 9000,  EnrollmentDate = DateTime.Parse("2017-01-25"),isOut = true, location="贵州",  suplierID = "007", price = 1.99,GoodsRFID = 20016},
                new Name {Goods = "手链",  number = 2220,  EnrollmentDate = DateTime.Parse("2016-11-11"),isOut = false,location="周口",  suplierID = "010", price = 25.0,GoodsRFID = 20017}
            };
            foreach(Name n in names)
            {
                Context.Names.Add(n);
            }
            Context.SaveChanges();

            var gits = new Git[]
            {
                new Git {GitID = 1020, Title = "易燃易爆类",position = "一楼"},
                new Git {GitID = 1120, Title = "易碎类",    position = "二楼"},
                new Git {GitID = 1230, Title = "电子类",    position = "三楼"},  
                new Git {GitID = 1702, Title = "贵重类" ,   position = "四楼"},
                new Git {GitID = 1550, Title = "常规物品",  position = "五楼"}
            };
            foreach(Git g in gits)
            {
                Context.Gits.Add(g);
            }
            Context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {NameID = 1,GitID = 1550,Address = Address.A },
                new Enrollment {NameID = 2,GitID = 1230,Address = Address.B },
                new Enrollment {NameID = 3,GitID = 1550,Address = Address.B },
                new Enrollment {NameID = 4,GitID = 1230,Address = Address.E },
                new Enrollment {NameID = 5,GitID = 1702,Address = Address.D },
                new Enrollment {NameID = 6,GitID = 1702,Address = Address.C }
            };

            foreach(Enrollment e in enrollments)
            {
                Context.Enrollments.Add(e);
            }
            Context.SaveChanges();

            var persons = new Person[]
            {
                new Person {PersonID = 5527,DepartmentId = "201",PersonName = "江泽鹏",Power = Power.G},
                new Person {PersonID = 5526,DepartmentId = "202",PersonName = "张三",  Power = Power.H},
                new Person {PersonID = 5525,DepartmentId = "203",PersonName = "二狗子",Power = Power.S},
                new Person {PersonID = 5524,DepartmentId = "204",PersonName = "狗蛋",  Power = Power.X}
            };

            foreach(Person p in persons)
            {
                Context.Persons.Add(p);
            }
            Context.SaveChanges();

            var department = new Department[]
            {
                new Department {DepartmentID = 201,type = "大货车组" },
                new Department {DepartmentID = 202,type = "空运组"   },
                new Department {DepartmentID = 203,type = "普通快递小哥组" },
                new Department {DepartmentID = 204,type = "仓库后勤组" }
            };

            foreach(Department d in department)
            {
                Context.Department.Add(d);
            }
            Context.SaveChanges();
        }
    }
}
