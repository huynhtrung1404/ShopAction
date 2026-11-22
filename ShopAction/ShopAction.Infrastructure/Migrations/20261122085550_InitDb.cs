using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAction.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261122085550_InitDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "user");

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("20b1eafc-8e44-4ac4-ae4d-a38a334e2376")),
                Name = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true),
                SortOrder = table.Column<int>(type: "integer", nullable: false),
                IsShowOnHome = table.Column<bool>(type: "boolean", nullable: false),
                ParentId = table.Column<int>(type: "integer", nullable: true),
                Status = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("38cd549c-e9aa-4d09-9a77-1fdf7226a96b")),
                FirstName = table.Column<string>(type: "text", nullable: true),
                LastName = table.Column<string>(type: "text", nullable: true),
                Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                HireDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Address = table.Column<string>(type: "text", nullable: true),
                ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Permissions",
            schema: "user",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d796fedc-a796-49c5-a869-6aa57e656432")),
                Code = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true),
                Module = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Permissions", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Roles",
            schema: "user",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("0ecac154-5436-42a1-975e-e506365e8d92")),
                Name = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true),
                IsSystemRole = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Suppliers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("992bcbac-42ff-4d7b-b26f-680e4d0d51ea")),
                CompanyName = table.Column<string>(type: "text", nullable: true),
                ContactName = table.Column<string>(type: "text", nullable: false),
                ContactTitle = table.Column<string>(type: "text", nullable: true),
                Address = table.Column<string>(type: "text", nullable: true),
                City = table.Column<string>(type: "text", nullable: true),
                Region = table.Column<string>(type: "text", nullable: true),
                Country = table.Column<string>(type: "text", nullable: true),
                Phone = table.Column<string>(type: "text", nullable: false),
                Homepage = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Suppliers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            schema: "user",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("356f870c-1817-4c51-8564-ed7140f6517f")),
                UserName = table.Column<string>(type: "text", nullable: true),
                Email = table.Column<string>(type: "text", nullable: true),
                Password = table.Column<string>(type: "text", nullable: true),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("07938807-3bc1-4814-8b75-aa15fc0a81dd")),
                OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                ShipName = table.Column<string>(type: "text", nullable: true),
                ShipAddress = table.Column<string>(type: "text", nullable: false),
                ShipEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                ShipPhoneNumber = table.Column<string>(type: "text", nullable: false),
                Status = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Orders_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "RolePermissions",
            schema: "user",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("f844b088-f4fa-4cf5-85fc-ed3cb71d5ec9")),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RolePermissions", x => x.Id);
                table.ForeignKey(
                    name: "FK_RolePermissions_Permissions_PermissionId",
                    column: x => x.PermissionId,
                    principalSchema: "user",
                    principalTable: "Permissions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_RolePermissions_Roles_RoleId",
                    column: x => x.RoleId,
                    principalSchema: "user",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d1fee817-7767-4ecf-93e8-de1bf7eaeb28")),
                Name = table.Column<string>(type: "text", nullable: false),
                SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                OriginalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                Stock = table.Column<int>(type: "integer", nullable: false),
                ViewCount = table.Column<int>(type: "integer", nullable: false),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                SeoAlias = table.Column<string>(type: "text", nullable: true),
                Discontinued = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Suppliers_SupplierId",
                    column: x => x.SupplierId,
                    principalTable: "Suppliers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "UserPermissions",
            schema: "user",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("09c07b80-8c4d-401a-8e8f-f81b58144cc6")),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                IsGranted = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserPermissions", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserPermissions_Permissions_PermissionId",
                    column: x => x.PermissionId,
                    principalSchema: "user",
                    principalTable: "Permissions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UserPermissions_Users_UserId",
                    column: x => x.UserId,
                    principalSchema: "user",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "UserRole",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRole", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserRole_Roles_RoleId",
                    column: x => x.RoleId,
                    principalSchema: "user",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UserRole_Users_UserId",
                    column: x => x.UserId,
                    principalSchema: "user",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("60b290c8-5141-4d8c-ad7d-80aec2224971")),
                ContactName = table.Column<string>(type: "text", nullable: true),
                Emal = table.Column<string>(type: "text", nullable: false),
                Address = table.Column<string>(type: "text", nullable: true),
                City = table.Column<string>(type: "text", nullable: true),
                Telephone = table.Column<string>(type: "text", nullable: false),
                Region = table.Column<string>(type: "text", nullable: false),
                OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
                table.ForeignKey(
                    name: "FK_Customers_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "CategoryProduct",
            columns: table => new
            {
                CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                table.ForeignKey(
                    name: "FK_CategoryProduct_Categories_CategoriesId",
                    column: x => x.CategoriesId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CategoryProduct_Products_ProductsId",
                    column: x => x.ProductsId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "OrderDetails",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("d9810dd1-3850-4bf7-b8aa-da5c8c3839de")),
                OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<int>(type: "integer", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderDetails", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderDetails_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_OrderDetails_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ProductImages",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("7371ee52-0147-428d-97a8-c787c0e52908")),
                ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                Path = table.Column<string>(type: "text", nullable: false),
                Caption = table.Column<string>(type: "text", nullable: false),
                IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                SortOrder = table.Column<int>(type: "integer", nullable: false),
                FileSize = table.Column<long>(type: "bigint", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedBy = table.Column<string>(type: "text", nullable: true),
                LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModifiedBy = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductImages", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProductImages_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CategoryProduct_ProductsId",
            table: "CategoryProduct",
            column: "ProductsId");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_OrderId",
            table: "Customers",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderDetails_OrderId",
            table: "OrderDetails",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderDetails_ProductId",
            table: "OrderDetails",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_EmployeeId",
            table: "Orders",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_ProductImages_ProductId",
            table: "ProductImages",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_SupplierId",
            table: "Products",
            column: "SupplierId");

        migrationBuilder.CreateIndex(
            name: "IX_RolePermissions_PermissionId",
            schema: "user",
            table: "RolePermissions",
            column: "PermissionId");

        migrationBuilder.CreateIndex(
            name: "IX_RolePermissions_RoleId",
            schema: "user",
            table: "RolePermissions",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_UserPermissions_PermissionId",
            schema: "user",
            table: "UserPermissions",
            column: "PermissionId");

        migrationBuilder.CreateIndex(
            name: "IX_UserPermissions_UserId",
            schema: "user",
            table: "UserPermissions",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRole_RoleId",
            table: "UserRole",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRole_UserId",
            table: "UserRole",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CategoryProduct");

        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "OrderDetails");

        migrationBuilder.DropTable(
            name: "ProductImages");

        migrationBuilder.DropTable(
            name: "RolePermissions",
            schema: "user");

        migrationBuilder.DropTable(
            name: "UserPermissions",
            schema: "user");

        migrationBuilder.DropTable(
            name: "UserRole");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Permissions",
            schema: "user");

        migrationBuilder.DropTable(
            name: "Roles",
            schema: "user");

        migrationBuilder.DropTable(
            name: "Users",
            schema: "user");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Suppliers");
    }
}
