using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addroleandaccountrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Role_RoleId",
                table: "AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_tb_m_account_AccountId",
                table: "AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "tb_m_role");

            migrationBuilder.RenameTable(
                name: "AccountRole",
                newName: "tb_m_accountrole");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRole_RoleId",
                table: "tb_m_accountrole",
                newName: "IX_tb_m_accountrole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRole_AccountId",
                table: "tb_m_accountrole",
                newName: "IX_tb_m_accountrole_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_role",
                table: "tb_m_role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accountrole",
                table: "tb_m_accountrole",
                column: "AccountRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accountrole_tb_m_account_AccountId",
                table: "tb_m_accountrole",
                column: "AccountId",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accountrole_tb_m_role_RoleId",
                table: "tb_m_accountrole",
                column: "RoleId",
                principalTable: "tb_m_role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_account_AccountId",
                table: "tb_m_accountrole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_role_RoleId",
                table: "tb_m_accountrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_role",
                table: "tb_m_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accountrole",
                table: "tb_m_accountrole");

            migrationBuilder.RenameTable(
                name: "tb_m_role",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "tb_m_accountrole",
                newName: "AccountRole");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_accountrole_RoleId",
                table: "AccountRole",
                newName: "IX_AccountRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_accountrole_AccountId",
                table: "AccountRole",
                newName: "IX_AccountRole_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole",
                column: "AccountRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Role_RoleId",
                table: "AccountRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_tb_m_account_AccountId",
                table: "AccountRole",
                column: "AccountId",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
