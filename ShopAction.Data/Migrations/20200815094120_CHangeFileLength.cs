using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAction.Data.Migrations
{
    public partial class CHangeFileLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c2781b86-10de-42d8-8105-d63d35113625"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("dcf955d8-ff45-46f0-bf20-5ebd5f725f3f"));

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("ec23d226-ad84-4295-9c11-358c9010efb2"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("b1c79d3f-be23-464e-8be6-abe9c16b2723"), false, "English" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("b1c79d3f-be23-464e-8be6-abe9c16b2723"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("ec23d226-ad84-4295-9c11-358c9010efb2"));

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("c2781b86-10de-42d8-8105-d63d35113625"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("dcf955d8-ff45-46f0-bf20-5ebd5f725f3f"), false, "English" });
        }
    }
}
