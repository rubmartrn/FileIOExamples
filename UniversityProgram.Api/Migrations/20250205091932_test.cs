using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProgram.Api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cpus_Laptops_LaptopId",
                table: "Cpus");

            migrationBuilder.DropIndex(
                name: "IX_Cpus_LaptopId",
                table: "Cpus");

            migrationBuilder.AlterColumn<int>(
                name: "LaptopId",
                table: "Cpus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus_LaptopId",
                table: "Cpus",
                column: "LaptopId",
                unique: true,
                filter: "[LaptopId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cpus_Laptops_LaptopId",
                table: "Cpus",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cpus_Laptops_LaptopId",
                table: "Cpus");

            migrationBuilder.DropIndex(
                name: "IX_Cpus_LaptopId",
                table: "Cpus");

            migrationBuilder.AlterColumn<int>(
                name: "LaptopId",
                table: "Cpus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cpus_LaptopId",
                table: "Cpus",
                column: "LaptopId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cpus_Laptops_LaptopId",
                table: "Cpus",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
