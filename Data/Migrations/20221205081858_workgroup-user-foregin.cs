using Microsoft.EntityFrameworkCore.Migrations;

namespace FraudPortal.Data.Migrations
{
    public partial class workgroupuserforegin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkGroupId",
                table: "UserInGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInGroups_WorkGroupId",
                table: "UserInGroups",
                column: "WorkGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInGroups_WorkGroups_WorkGroupId",
                table: "UserInGroups",
                column: "WorkGroupId",
                principalTable: "WorkGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInGroups_WorkGroups_WorkGroupId",
                table: "UserInGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserInGroups_WorkGroupId",
                table: "UserInGroups");

            migrationBuilder.DropColumn(
                name: "WorkGroupId",
                table: "UserInGroups");
        }
    }
}
