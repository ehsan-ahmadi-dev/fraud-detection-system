using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FraudPortal.Data.Migrations
{
    public partial class fraud_Fact_Portal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkGroupName",
                table: "UserInGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "fraud_Fact_Portal",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_id = table.Column<long>(type: "bigint", nullable: true),
                    Rull_id = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<long>(type: "bigint", nullable: true),
                    TypePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Risk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SourcePan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationSECPAN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EncryptDestinationPAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal = table.Column<long>(type: "bigint", nullable: true),
                    User_Id = table.Column<long>(type: "bigint", nullable: true),
                    GuildTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrCode_Id = table.Column<int>(type: "int", nullable: true),
                    PosConnectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfTransaction_Success = table.Column<int>(type: "int", nullable: true),
                    CountOfTransaction_unSuccess = table.Column<int>(type: "int", nullable: true),
                    Amount_Success = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount_unSuccess = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CountOfTerminal = table.Column<int>(type: "int", nullable: true),
                    CountOfSourcePan = table.Column<int>(type: "int", nullable: true),
                    CountOfRepeat = table.Column<int>(type: "int", nullable: true),
                    DiffTime1 = table.Column<int>(type: "int", nullable: true),
                    DiffTime2 = table.Column<int>(type: "int", nullable: true),
                    P_Unsucsess = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P_SorcePan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Detail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail2 = table.Column<long>(type: "bigint", nullable: true),
                    Detail3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Detail4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fraud_Fact_Portal", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fraud_Fact_Portal");

            migrationBuilder.AlterColumn<string>(
                name: "WorkGroupName",
                table: "UserInGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
