using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAction.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261122091015_InitinalData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Users",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("356f870c-1817-4c51-8564-ed7140f6517f"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "UserPermissions",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("09c07b80-8c4d-401a-8e8f-f81b58144cc6"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Suppliers",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("992bcbac-42ff-4d7b-b26f-680e4d0d51ea"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Roles",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("0ecac154-5436-42a1-975e-e506365e8d92"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "RolePermissions",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("f844b088-f4fa-4cf5-85fc-ed3cb71d5ec9"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Products",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("d1fee817-7767-4ecf-93e8-de1bf7eaeb28"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "ProductImages",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("7371ee52-0147-428d-97a8-c787c0e52908"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Permissions",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("d796fedc-a796-49c5-a869-6aa57e656432"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Orders",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("07938807-3bc1-4814-8b75-aa15fc0a81dd"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "OrderDetails",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("d9810dd1-3850-4bf7-b8aa-da5c8c3839de"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Employees",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("38cd549c-e9aa-4d09-9a77-1fdf7226a96b"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Customers",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("60b290c8-5141-4d8c-ad7d-80aec2224971"));

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Categories",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValue: new Guid("20b1eafc-8e44-4ac4-ae4d-a38a334e2376"));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Users",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("356f870c-1817-4c51-8564-ed7140f6517f"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "UserPermissions",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("09c07b80-8c4d-401a-8e8f-f81b58144cc6"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Suppliers",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("992bcbac-42ff-4d7b-b26f-680e4d0d51ea"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Roles",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("0ecac154-5436-42a1-975e-e506365e8d92"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "RolePermissions",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("f844b088-f4fa-4cf5-85fc-ed3cb71d5ec9"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Products",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("d1fee817-7767-4ecf-93e8-de1bf7eaeb28"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "ProductImages",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("7371ee52-0147-428d-97a8-c787c0e52908"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            schema: "user",
            table: "Permissions",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("d796fedc-a796-49c5-a869-6aa57e656432"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Orders",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("07938807-3bc1-4814-8b75-aa15fc0a81dd"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "OrderDetails",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("d9810dd1-3850-4bf7-b8aa-da5c8c3839de"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Employees",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("38cd549c-e9aa-4d09-9a77-1fdf7226a96b"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Customers",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("60b290c8-5141-4d8c-ad7d-80aec2224971"),
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Categories",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("20b1eafc-8e44-4ac4-ae4d-a38a334e2376"),
            oldClrType: typeof(Guid),
            oldType: "uuid");
    }
}