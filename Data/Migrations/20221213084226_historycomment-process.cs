using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FraudPortal.Data.Migrations
{
    public partial class historycommentprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "processes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    refineId = table.Column<long>(type: "bigint", nullable: false),
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
                    Detail4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionDueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    editDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historyComments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionDueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    editDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    processId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historyComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_historyComments_processes_processId",
                        column: x => x.processId,
                        principalTable: "processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historyComments_processId",
                table: "historyComments",
                column: "processId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historyComments");

            migrationBuilder.DropTable(
                name: "processes");
        }
    }
}
