using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsAPIExercise.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(65)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starship_class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost_in_credits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max_atmosphering_speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hyperdrive_rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MGLT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo_capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edited = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "starships");
        }
    }
}
