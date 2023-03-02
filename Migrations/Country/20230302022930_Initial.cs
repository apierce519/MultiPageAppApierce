using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace MultiPageAppApierce.Migrations.Country
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "archery", "Archery/Indoor" },
                    { "bobsleigh", "Bobsleigh/Outdoor" },
                    { "breakdancing", "Breakdancing/Indoor" },
                    { "curling", "Curling/Indoor" },
                    { "diving", "Diving/Indoor" },
                    { "roadCycle", "Road Cycling/Outdoor" },
                    { "skateboarding", "Skateboarding/Outdoor" },
                    { "sprint", "Sprint/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameName" },
                values: new object[,]
                {
                    { "para", "Paralympics" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Oliympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CategoryId", "CountryFlag", "GameId", "Name" },
                values: new object[,]
                {
                    { "aus", "sprint", "AUS.png", "para", "Austria" },
                    { "bra", "roadCycle", "BRA.png", "summer", "Brazil" },
                    { "can", "curling", "CAN.png", "winter", "Canada" },
                    { "chi", "diving", "CHI.png", "summer", "China" },
                    { "fin", "skateboarding", "FIN.png", "youth", "Finland" },
                    { "fra", "breakdancing", "FRA.png", "youth", "France" },
                    { "gb", "curling", "GB.png", "winter", "Great Britain" },
                    { "ger", "diving", "GER.png", "summer", "Germany" },
                    { "ita", "bobsleigh", "ITA.png", "winter", "Italy" },
                    { "jam", "bobsleigh", "JAM.png", "winter", "Jamaica" },
                    { "jap", "bobsleigh", "JAP.png", "winter", "Japan" },
                    { "mex", "diving", "MEX.png", "summer", "Mexico" },
                    { "net", "roadCycle", "NET.png", "summer", "Netherlands" },
                    { "pak", "sprint", "PAK.png", "para", "Pakistan" },
                    { "por", "skateboarding", "POR.png", "youth", "Portugal" },
                    { "rus", "breakdancing", "RUS.png", "youth", "Russia" },
                    { "slo", "skateboarding", "SLO.png", "youth", "Slovakia" },
                    { "swe", "curling", "SWE.png", "winter", "Sweden" },
                    { "tha", "archery", "THA.png", "para", "Thailand" },
                    { "ukr", "archery", "UKR.png", "para", "Ukraine" },
                    { "uru", "archery", "URU.png", "para", "Uruguay" },
                    { "usa", "roadCycle", "USA.png", "summer", "USA" },
                    { "zim", "sprint", "ZIM.png", "para", "Zimbabwe" },
                    { "zyp", "breakdancing", "CYP.png", "youth", "Cyprus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryId",
                table: "Countries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
