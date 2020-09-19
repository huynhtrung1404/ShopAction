using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAction.Data.Migrations
{
    public partial class BugFixingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("b1c79d3f-be23-464e-8be6-abe9c16b2723"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("ec23d226-ad84-4295-9c11-358c9010efb2"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("8431d434-cf6e-4900-9efd-1c7a6b5c6651"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("b2df9a18-b980-42ff-846c-247d9dbf2745"), false, "English" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("8431d434-cf6e-4900-9efd-1c7a6b5c6651"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("b2df9a18-b980-42ff-846c-247d9dbf2745"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations",
                columns: new[] { "LanguageId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "LanguageId" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("ec23d226-ad84-4295-9c11-358c9010efb2"), true, "Tieng Viet" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[] { new Guid("b1c79d3f-be23-464e-8be6-abe9c16b2723"), false, "English" });
        }
    }
}
