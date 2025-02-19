using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProgram.Api.Migrations
{
    /// <inheritdoc />
    public partial class address2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Address2", "Email", "LibraryId", "Money", "Name" },
                values: new object[] { 1, "123", null, "m@a.com", null, 0m, "John" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Students");
        }
    }
}
