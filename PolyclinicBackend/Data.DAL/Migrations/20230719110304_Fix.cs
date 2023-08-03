using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Records",
                newName: "DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Credentials",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Credentials");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Records",
                newName: "Date");
        }
    }
}
