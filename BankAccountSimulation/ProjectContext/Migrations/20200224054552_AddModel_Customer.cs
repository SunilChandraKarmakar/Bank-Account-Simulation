using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectContext.Migrations
{
    public partial class AddModel_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    ContactNo = table.Column<string>(maxLength: 14, nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                table: "Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email_ContactNo",
                table: "Customers",
                columns: new[] { "Email", "ContactNo" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
