using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Depot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Git",
                columns: table => new
                {
                    GitID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Git", x => x.GitID);
                });

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    Goods = table.Column<string>(nullable: true),
                    isOut = table.Column<bool>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    suplierID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<int>(nullable: true),
                    GitID = table.Column<int>(nullable: false),
                    NameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Git_GitID",
                        column: x => x.GitID,
                        principalTable: "Git",
                        principalColumn: "GitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Name_NameID",
                        column: x => x.NameID,
                        principalTable: "Name",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_GitID",
                table: "Enrollment",
                column: "GitID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_NameID",
                table: "Enrollment",
                column: "NameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Git");

            migrationBuilder.DropTable(
                name: "Name");
        }
    }
}
