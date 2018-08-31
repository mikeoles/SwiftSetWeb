using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class original : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultiChoice",
                table: "SortingGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOriginal",
                table: "SortingGroups",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMultiChoice",
                table: "SortingGroups");

            migrationBuilder.DropColumn(
                name: "IsOriginal",
                table: "SortingGroups");
        }
    }
}
