using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sortingCategory_SortingGroup_groupId",
                table: "sortingCategory");

            migrationBuilder.DropTable(
                name: "SortingGroup");

            migrationBuilder.DropIndex(
                name: "IX_sortingCategory_groupId",
                table: "sortingCategory");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "sortingCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "sortingCategory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SortingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortingGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sortingCategory_groupId",
                table: "sortingCategory",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_sortingCategory_SortingGroup_groupId",
                table: "sortingCategory",
                column: "groupId",
                principalTable: "SortingGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
