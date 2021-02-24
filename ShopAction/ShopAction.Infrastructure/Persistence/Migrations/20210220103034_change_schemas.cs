using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAction.Infrastructure.Persistence.Migrations
{
    public partial class change_schemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transactions",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "Promotions",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "ProductTranslations",
                newName: "ProductTranslations",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "ProductInCategories",
                newName: "ProductInCategories",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImages",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetails",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Languages",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contacts",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "CategoryTranslations",
                newName: "CategoryTranslations",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Carts",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "ShopAction");

            migrationBuilder.RenameTable(
                name: "AppConfigs",
                newName: "AppConfigs",
                newSchema: "ShopAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Transactions",
                schema: "ShopAction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Promotions",
                schema: "ShopAction",
                newName: "Promotions");

            migrationBuilder.RenameTable(
                name: "ProductTranslations",
                schema: "ShopAction",
                newName: "ProductTranslations");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "ShopAction",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductInCategories",
                schema: "ShopAction",
                newName: "ProductInCategories");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                schema: "ShopAction",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "ShopAction",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "ShopAction",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Languages",
                schema: "ShopAction",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "ShopAction",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "CategoryTranslations",
                schema: "ShopAction",
                newName: "CategoryTranslations");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "ShopAction",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "ShopAction",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "ShopAction",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "ShopAction",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "ShopAction",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "ShopAction",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "ShopAction",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "ShopAction",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "ShopAction",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AppConfigs",
                schema: "ShopAction",
                newName: "AppConfigs");
        }
    }
}
