using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addtabeltransacsion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_account_AccountId",
                table: "tb_m_accountrole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accountrole_tb_m_role_RoleId",
                table: "tb_m_accountrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accountrole",
                table: "tb_m_accountrole");

            migrationBuilder.RenameTable(
                name: "tb_m_accountrole",
                newName: "tb_tr_accountrole");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_accountrole_RoleId",
                table: "tb_tr_accountrole",
                newName: "IX_tb_tr_accountrole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_accountrole_AccountId",
                table: "tb_tr_accountrole",
                newName: "IX_tb_tr_accountrole_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_accountrole",
                table: "tb_tr_accountrole",
                column: "AccountRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_accountrole_tb_m_account_AccountId",
                table: "tb_tr_accountrole",
                column: "AccountId",
                principalTable: "tb_m_account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_accountrole_tb_m_role_RoleId",
                table: "tb_tr_accountrole",
                column: "RoleId",
                principalTable: "tb_m_role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_accountrole_tb_m_account_AccountId",
                table: "tb_tr_accountrole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_accountrole_tb_m_role_RoleId",
                table: "tb_tr_accountrole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_accountrole",
                table: "tb_tr_accountrole");

            migrationBuilder.RenameTable(
                name: "tb_tr_accountrole",
                newName: "tb_m_accountrole");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_accountrole_RoleId",
                table: "tb_m_accountrole",
                newName: "IX_tb_m_accountrole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_accountrole_AccountId",
                table: "tb_m_accountrole",
                newName: "IX_tb_m_accountrole_AccountId");

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
    }
}
