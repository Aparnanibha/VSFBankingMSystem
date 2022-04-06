using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    public partial class addBalancecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Balance",
            //    table: "CustomerAcc");

            migrationBuilder.AddColumn<double>(
                name: "TotalBalance",
                table: "CustomerAcc",
                type: "float",
                nullable: false,
                defaultValue: 2000.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "CustomerAcc");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "CustomerAcc",
                type: "float",
                nullable: true);
        }
    }
}
