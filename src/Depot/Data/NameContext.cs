using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Depot.Models;
using Microsoft.EntityFrameworkCore;

namespace Depot.Data
{
    public class NameContext: DbContext
    {
        public NameContext(DbContextOptions<NameContext> options):base(options)
        {

        }

            //上下文
        public DbSet<Git> Gits { get; set; }            //DbSet 为每个实体集创建属性
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Person> Persons { get; set; }
        //public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Git>().ToTable("Git");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Name>().ToTable("Name");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<InterGoodsDetail>().ToTable("InterGoodsDetail");
            modelBuilder.Entity<DataDetail>().ToTable("DataDetail");
            modelBuilder.Entity<OutGoods>().ToTable("OutGoods");
        }

        public DbSet<Department> Department{ get; set; }

        public DbSet<Book> Book { get; set; }
        public DbSet<InterGoodsDetail> InterGoodsDetail { get; set; }
        public DbSet<DataDetail> DataDetail { get; set; }
        public DbSet<OutGoods> OutGoods { get; set; }
    }
}
