using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingManagementSystem.Migrations
{
    public partial class addeddatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "fk_AccNum_Tr",
            //    table: "TransactionDetail");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "TransactionDate",
            //    table: "TransactionDetail",
            //    type: "date",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "ToAccountNumber",
            //    table: "TransactionDetail",
            //    type: "numeric(12,0)",
            //    nullable: false,
            //    defaultValue: 0m,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Maturityinstruct",
            //    table: "TransactionDetail",
            //    type: "varchar(40)",
            //    unicode: false,
            //    maxLength: 40,
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "varchar(40)",
            //    oldUnicode: false,
            //    oldMaxLength: 40,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "AccountNumber",
            //    table: "TransactionDetail",
            //    type: "numeric(12,0)",
            //    nullable: false,
            //    defaultValue: 0m,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)",
            //    oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalBalance",
                table: "CustomerAcc",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            //migrationBuilder.AddForeignKey(
            //    name: "fk_AccNum_Tr",
            //    table: "TransactionDetail",
            //    column: "AccountNumber",
            //    principalTable: "CustomerAcc",
            //    principalColumn: "AccountNumber",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "fk_AccNum_Tr",
            //    table: "TransactionDetail");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "TransactionDate",
            //    table: "TransactionDetail",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "ToAccountNumber",
            //    table: "TransactionDetail",
            //    type: "numeric(12,0)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Maturityinstruct",
            //    table: "TransactionDetail",
            //    type: "varchar(40)",
            //    unicode: false,
            //    maxLength: 40,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(40)",
            //    oldUnicode: false,
            //    oldMaxLength: 40);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "AccountNumber",
            //    table: "TransactionDetail",
            //    type: "numeric(12,0)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "numeric(12,0)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalBalance",
                table: "CustomerAcc",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            //migrationBuilder.AddForeignKey(
            //    name: "fk_AccNum_Tr",
            //    table: "TransactionDetail",
            //    column: "AccountNumber",
            //    principalTable: "CustomerAcc",
            //    principalColumn: "AccountNumber");
        }
    }
}
