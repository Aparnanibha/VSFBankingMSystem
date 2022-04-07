using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    public partial class AddingDebitCreditColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebitCredit",
                table: "TransactionDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BeneficiaryAccountNumber",
                table: "AddPayee",
                type: "numeric(12,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,0)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebitCredit",
                table: "TransactionDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "BeneficiaryAccountNumber",
                table: "AddPayee",
                type: "numeric(12,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,0)");
        }
    }
}
