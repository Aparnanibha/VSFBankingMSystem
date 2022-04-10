using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    public partial class CustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterNetBankings_CustomerAcc_CustomerAccAccountNumber",
                table: "RegisterNetBankings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterNetBankings",
                table: "RegisterNetBankings");

            migrationBuilder.DropIndex(
                name: "IX_RegisterNetBankings_CustomerAccAccountNumber",
                table: "RegisterNetBankings");

            migrationBuilder.DropColumn(
                name: "CustomerAccAccountNumber",
                table: "RegisterNetBankings");

            migrationBuilder.RenameTable(
                name: "RegisterNetBankings",
                newName: "RegisterNetBanking");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionPassword",
                table: "RegisterNetBanking",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Passwordd",
                table: "RegisterNetBanking",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountNumber",
                table: "RegisterNetBanking",
                type: "numeric(12,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "RegisterNetBanking",
                type: "varchar(12)",
                unicode: false,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Register__24602B23768E2252",
                table: "RegisterNetBanking",
                columns: new[] { "AccountNumber", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "fk_AccNum",
                table: "RegisterNetBanking",
                column: "AccountNumber",
                principalTable: "CustomerAcc",
                principalColumn: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_AccNum",
                table: "RegisterNetBanking");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Register__24602B23768E2252",
                table: "RegisterNetBanking");

            migrationBuilder.RenameTable(
                name: "RegisterNetBanking",
                newName: "RegisterNetBankings");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionPassword",
                table: "RegisterNetBankings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Passwordd",
                table: "RegisterNetBankings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "RegisterNetBankings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountNumber",
                table: "RegisterNetBankings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,0)");

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerAccAccountNumber",
                table: "RegisterNetBankings",
                type: "numeric(12,0)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterNetBankings",
                table: "RegisterNetBankings",
                column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RegisterNetBankings_CustomerAccAccountNumber",
            //    table: "RegisterNetBankings",
            //    column: "CustomerAccAccountNumber");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RegisterNetBankings_CustomerAcc_CustomerAccAccountNumber",
            //    table: "RegisterNetBankings",
            //    column: "CustomerAccAccountNumber",
            //    principalTable: "CustomerAcc",
            //    principalColumn: "AccountNumber");
        }
    }
}
