using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAction.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261122143759_UpdateDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Users_Password",
            schema: "user",
            table: "Users",
            column: "Password");

        migrationBuilder.CreateIndex(
            name: "IX_Users_UserName",
            schema: "user",
            table: "Users",
            column: "UserName",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Users_Password",
            schema: "user",
            table: "Users");

        migrationBuilder.DropIndex(
            name: "IX_Users_UserName",
            schema: "user",
            table: "Users");
    }
}
