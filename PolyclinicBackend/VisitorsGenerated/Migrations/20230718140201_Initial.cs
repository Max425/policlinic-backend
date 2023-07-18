using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VisitorGenerated.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitorsGenerated",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    PassportSeries = table.Column<int>(type: "integer", nullable: false),
                    PassportNumber = table.Column<int>(type: "integer", nullable: false),
                    PhotoBase64 = table.Column<string>(type: "text", nullable: false),
                    DateIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorsGenerated", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorsGenerated");
        }
    }
}
