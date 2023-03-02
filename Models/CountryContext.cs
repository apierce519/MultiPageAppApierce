using Microsoft.EntityFrameworkCore;

namespace MultiPageAppApierce.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = "winter", GameName = "Winter Olympics" },
                new Game { GameId = "summer", GameName = "Summer Olympics" },
                new Game { GameId = "para", GameName = "Paralympics" },
                new Game { GameId = "youth", GameName = "Youth Oliympic Games" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "curling", CategoryName = "Curling/Indoor" },
                new Category { CategoryId = "bobsleigh", CategoryName = "Bobsleigh/Outdoor" },
                new Category { CategoryId = "diving", CategoryName = "Diving/Indoor" },
                new Category { CategoryId = "roadCycle", CategoryName = "Road Cycling/Outdoor" },
                new Category { CategoryId = "archery", CategoryName = "Archery/Indoor" },
                new Category { CategoryId = "sprint", CategoryName = "Sprint/Outdoor" },
                new Category { CategoryId = "breakdancing", CategoryName = "Breakdancing/Indoor" },
                new Category { CategoryId = "skateboarding", CategoryName = "Skateboarding/Outdoor" }
        );

            modelBuilder.Entity<Country>().HasData(
                new { CountryId = "can", Name = "Canada", GameId = "winter", CategoryId = "curling", CountryFlag = "CAN.png" },
                new { CountryId = "swe", Name = "Sweden", GameId = "winter", CategoryId = "curling", CountryFlag = "SWE.png" },
                new { CountryId = "gb", Name = "Great Britain", GameId = "winter", CategoryId = "curling", CountryFlag = "GB.png" },
                new { CountryId = "jam", Name = "Jamaica", GameId = "winter", CategoryId = "bobsleigh", CountryFlag = "JAM.png" },
                new { CountryId = "ita", Name = "Italy", GameId = "winter", CategoryId = "bobsleigh", CountryFlag = "ITA.png" },
                new { CountryId = "jap", Name = "Japan", GameId = "winter", CategoryId = "bobsleigh", CountryFlag = "JAP.png" },
                new { CountryId = "ger", Name = "Germany", GameId = "summer", CategoryId = "diving", CountryFlag = "GER.png" },
                new { CountryId = "chi", Name = "China", GameId = "summer", CategoryId = "diving", CountryFlag = "CHI.png" },
                new { CountryId = "mex", Name = "Mexico", GameId = "summer", CategoryId = "diving", CountryFlag = "MEX.png" },
                new { CountryId = "bra", Name = "Brazil", GameId = "summer", CategoryId = "roadCycle", CountryFlag = "BRA.png" },
                new { CountryId = "net", Name = "Netherlands", GameId = "summer", CategoryId = "roadCycle", CountryFlag = "NET.png" },
                new { CountryId = "usa", Name = "USA", GameId = "summer", CategoryId = "roadCycle", CountryFlag = "USA.png" },
                new { CountryId = "tha", Name = "Thailand", GameId = "para", CategoryId = "archery", CountryFlag = "THA.png" },
                new { CountryId = "uru", Name = "Uruguay", GameId = "para", CategoryId = "archery", CountryFlag = "URU.png" },
                new { CountryId = "ukr", Name = "Ukraine", GameId = "para", CategoryId = "archery", CountryFlag = "UKR.png" },
                new { CountryId = "aus", Name = "Austria", GameId = "para", CategoryId = "sprint", CountryFlag = "AUS.png" },
                new { CountryId = "pak", Name = "Pakistan", GameId = "para", CategoryId = "sprint", CountryFlag = "PAK.png" },
                new { CountryId = "zim", Name = "Zimbabwe", GameId = "para", CategoryId = "sprint", CountryFlag = "ZIM.png" },
                new { CountryId = "fra", Name = "France", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "FRA.png" },
                new { CountryId = "zyp", Name = "Cyprus", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "CYP.png" },
                new { CountryId = "rus", Name = "Russia", GameId = "youth", CategoryId = "breakdancing", CountryFlag = "RUS.png" },
                new { CountryId = "fin", Name = "Finland", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "FIN.png" },
                new { CountryId = "slo", Name = "Slovakia", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "SLO.png" },
                new { CountryId = "por", Name = "Portugal", GameId = "youth", CategoryId = "skateboarding", CountryFlag = "POR.png" }
                );

        }
    }
}

