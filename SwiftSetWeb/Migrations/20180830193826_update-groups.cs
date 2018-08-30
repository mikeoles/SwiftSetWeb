using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class updategroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sortingCategory_SortingGroups_GroupId",
                table: "sortingCategory");

            migrationBuilder.DropIndex(
                name: "IX_sortingCategory_GroupId",
                table: "sortingCategory");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "sortingCategory");

            migrationBuilder.AddColumn<int>(
                name: "SortingGroupId",
                table: "sortingCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sortingCategory_SortingGroupId",
                table: "sortingCategory",
                column: "SortingGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_sortingCategory_SortingGroups_SortingGroupId",
                table: "sortingCategory",
                column: "SortingGroupId",
                principalTable: "SortingGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sortingCategory_SortingGroups_SortingGroupId",
                table: "sortingCategory");

            migrationBuilder.DropIndex(
                name: "IX_sortingCategory_SortingGroupId",
                table: "sortingCategory");

            migrationBuilder.DropColumn(
                name: "SortingGroupId",
                table: "sortingCategory");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "sortingCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sortingCategory_GroupId",
                table: "sortingCategory",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_sortingCategory_SortingGroups_GroupId",
                table: "sortingCategory",
                column: "GroupId",
                principalTable: "SortingGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
