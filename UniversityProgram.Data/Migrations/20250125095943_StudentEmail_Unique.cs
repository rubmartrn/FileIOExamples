﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProgram.Api.Migrations
{
    /// <inheritdoc />
    public partial class StudentEmail_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Email",
                table: "Students");
        }
    }
}
