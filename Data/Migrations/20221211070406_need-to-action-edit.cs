using Microsoft.EntityFrameworkCore.Migrations;

namespace FraudPortal.Data.Migrations
{
    public partial class needtoactionedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NeedToAction",
                table: "fraud_Fact_Portal",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "No");

            migrationBuilder.AddColumn<string>(
                name: "editdate",
                table: "fraud_Fact_Portal",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedToAction",
                table: "fraud_Fact_Portal");

            migrationBuilder.DropColumn(
                name: "editdate",
                table: "fraud_Fact_Portal");
        }
    }
}
