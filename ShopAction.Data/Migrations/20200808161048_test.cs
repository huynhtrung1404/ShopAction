using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAction.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7a6f8af5-551f-46c5-9d29-ba7abb64da95"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e19e2bc7-3ea5-489e-9acf-52a11fa80173"));

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("d06aa8aa-4e47-4ced-a3f4-b58b16d57d87"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("09429a70-941c-48f4-a67a-e4057cbe34a8"), false, "English" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("09429a70-941c-48f4-a67a-e4057cbe34a8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d06aa8aa-4e47-4ced-a3f4-b58b16d57d87"));

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("e19e2bc7-3ea5-489e-9acf-52a11fa80173"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("7a6f8af5-551f-46c5-9d29-ba7abb64da95"), false, "English" });
        }
    }
}
