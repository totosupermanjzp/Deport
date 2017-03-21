using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Depot.Data;

namespace Depot.Migrations
{
    [DbContext(typeof(NameContext))]
    partial class NameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Depot.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Address");

                    b.Property<int>("GitID");

                    b.Property<int>("NameID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("GitID");

                    b.HasIndex("NameID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("Depot.Models.Git", b =>
                {
                    b.Property<int>("GitID");

                    b.Property<string>("Title");

                    b.Property<string>("position");

                    b.HasKey("GitID");

                    b.ToTable("Git");
                });

            modelBuilder.Entity("Depot.Models.Name", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("Goods");

                    b.Property<bool>("isOut");

                    b.Property<string>("location");

                    b.Property<int>("number");

                    b.Property<double>("price");

                    b.Property<string>("suplierID");

                    b.HasKey("ID");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("Depot.Models.Person", b =>
                {
                    b.Property<string>("PersonID");

                    b.Property<string>("DepartmentId");

                    b.Property<string>("PersonName");

                    b.Property<int?>("Power");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Depot.Models.Enrollment", b =>
                {
                    b.HasOne("Depot.Models.Git", "Git")
                        .WithMany("Enrollments")
                        .HasForeignKey("GitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Depot.Models.Name", "Name")
                        .WithMany("Enrollments")
                        .HasForeignKey("NameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
