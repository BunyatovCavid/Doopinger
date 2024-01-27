using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BubbleAPi.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Cross_Roles_RoleId",
                table: "User_Role_Cross");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Cross_Users_UserId",
                table: "User_Role_Cross");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Role_Cross",
                table: "User_Role_Cross");

            migrationBuilder.RenameTable(
                name: "User_Role_Cross",
                newName: "User_Role_Crosses");

            migrationBuilder.RenameIndex(
                name: "IX_User_Role_Cross_RoleId",
                table: "User_Role_Crosses",
                newName: "IX_User_Role_Crosses_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Role_Crosses",
                table: "User_Role_Crosses",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Crosses_Roles_RoleId",
                table: "User_Role_Crosses",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Crosses_Users_UserId",
                table: "User_Role_Crosses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Crosses_Roles_RoleId",
                table: "User_Role_Crosses");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Crosses_Users_UserId",
                table: "User_Role_Crosses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Role_Crosses",
                table: "User_Role_Crosses");

            migrationBuilder.RenameTable(
                name: "User_Role_Crosses",
                newName: "User_Role_Cross");

            migrationBuilder.RenameIndex(
                name: "IX_User_Role_Crosses_RoleId",
                table: "User_Role_Cross",
                newName: "IX_User_Role_Cross_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Role_Cross",
                table: "User_Role_Cross",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Cross_Roles_RoleId",
                table: "User_Role_Cross",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Cross_Users_UserId",
                table: "User_Role_Cross",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
