using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class movecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseColumnName",
                table: "sortingCategory");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseColumnName",
                table: "SortingGroups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseColumnName",
                table: "SortingGroups");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseColumnName",
                table: "sortingCategory",
                maxLength: 50,
                nullable: true);
        }
    }
}
