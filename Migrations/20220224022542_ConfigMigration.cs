using Microsoft.EntityFrameworkCore.Migrations;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Migrations
{
    public partial class ConfigMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbMachine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    failProbability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productsPerHour = table.Column<int>(type: "int", nullable: false),
                    timeToFix = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMachine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbContinuosProdEmulate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machineid = table.Column<int>(type: "int", nullable: true),
                    productid = table.Column<int>(type: "int", nullable: true),
                    dailyHours = table.Column<int>(type: "int", nullable: false),
                    weeklyDays = table.Column<int>(type: "int", nullable: false),
                    hourCost = table.Column<float>(type: "real", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbContinuosProdEmulate", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbContinuosProdEmulate_tbMachine_machineid",
                        column: x => x.machineid,
                        principalTable: "tbMachine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbContinuosProdEmulate_tbProducts_productid",
                        column: x => x.productid,
                        principalTable: "tbProducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbContinuosProdEmulate",
                columns: new[] { "id", "Months", "dailyHours", "days", "hourCost", "hours", "machineid", "productid", "weeklyDays" },
                values: new object[,]
                {
                    { 1, 6, 8, 0, 10f, 0, null, null, 6 },
                    { 2, 4, 12, 0, 15f, 0, null, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "tbMachine",
                columns: new[] { "id", "failProbability", "name", "productsPerHour", "status", "timeToFix" },
                values: new object[,]
                {
                    { 1, "1,0", null, 100, true, 3 },
                    { 2, "0,7", null, 100, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "tbProducts",
                columns: new[] { "id", "name", "productPrice" },
                values: new object[,]
                {
                    { 1, "Clavos", 5f },
                    { 2, "Tornillos", 5f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbContinuosProdEmulate_machineid",
                table: "tbContinuosProdEmulate",
                column: "machineid");

            migrationBuilder.CreateIndex(
                name: "IX_tbContinuosProdEmulate_productid",
                table: "tbContinuosProdEmulate",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbContinuosProdEmulate");

            migrationBuilder.DropTable(
                name: "tbMachine");

            migrationBuilder.DropTable(
                name: "tbProducts");
        }
    }
}
