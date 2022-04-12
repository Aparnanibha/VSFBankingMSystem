using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    public partial class ChangingDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "fk_AccNum_AddPay",
            //    table: "AddPayee");

            //migrationBuilder.DropTable(
            //    name: "registrations");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_123",
            //    table: "AddPayee");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Customer",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AadharNumber",
                table: "Customer",
                type: "varchar(16)",
                unicode: false,
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(16,0)",
                oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "AccountNumber",
            //    table: "AddPayee",
            //    type: "numeric(12,0)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_123",
            //    table: "AddPayee",
            //    column: "BeneficiaryAccountNumber");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AddPayee_AccountNumber",
            //    table: "AddPayee",
            //    column: "AccountNumber");

            //migrationBuilder.AddForeignKey(
            //    name: "fk_AccNum_AddPay",
            //    table: "AddPayee",
            //    column: "AccountNumber",
            //    principalTable: "CustomerAcc",
            //    principalColumn: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "fk_AccNum_AddPay",
            //    table: "AddPayee");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_123",
            //    table: "AddPayee");

            //migrationBuilder.DropIndex(
            //    name: "IX_AddPayee_AccountNumber",
            //    table: "AddPayee");

            migrationBuilder.AlterColumn<decimal>(
                name: "MobileNumber",
                table: "Customer",
                type: "numeric(10,0)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AadharNumber",
                table: "Customer",
                type: "numeric(16,0)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldUnicode: false,
                oldMaxLength: 16,
                oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "AccountNumber",
            //    table: "AddPayee",
            //    type: "numeric(12,0)",
            //    nullable: false,
            //    defaultValue: 0m,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)",
            //    oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_123",
            //    table: "AddPayee",
            //    column: "AccountNumber");

            //migrationBuilder.CreateTable(
            //    name: "registrations",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TransactionPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        password = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_registrations", x => x.Id);
            //    });

            //migrationBuilder.AddForeignKey(
            //    name: "fk_AccNum_AddPay",
            //    table: "AddPayee",
            //    column: "AccountNumber",
            //    principalTable: "CustomerAcc",
            //    principalColumn: "AccountNumber",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
