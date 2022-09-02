using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerships.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDealership",
                columns: table => new
                {
                    IdCarDealership = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealership", x => x.IdCarDealership);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stamp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdCarDealership = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Car_CarDealership",
                        column: x => x.IdCarDealership,
                        principalTable: "CarDealership",
                        principalColumn: "IdCarDealership",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_IdCarDealership",
                table: "Car",
                column: "IdCarDealership");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarDealership");
        }
    }
}
