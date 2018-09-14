using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class NewOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewOptions",
                columns: table => new
                {
                    SortingGroupId = table.Column<int>(nullable: false),
                    SortingCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOptions", x => new { x.SortingGroupId, x.SortingCategoryId });
                    table.ForeignKey(
                        name: "FK_NewOptions_sortingCategory_SortingCategoryId",
                        column: x => x.SortingCategoryId,
                        principalTable: "sortingCategory",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewOptions_SortingGroups_SortingGroupId",
                        column: x => x.SortingGroupId,
                        principalTable: "SortingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewOptions_SortingCategoryId",
                table: "NewOptions",
                column: "SortingCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewOptions");

            migrationBuilder.CreateTable(
                name: "SortingGroupSortingCategory",
                columns: table => new
                {
                    SortingGroupId = table.Column<int>(nullable: false),
                    SortingCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortingGroupSortingCategory", x => new { x.SortingGroupId, x.SortingCategoryId });
                    table.ForeignKey(
                        name: "FK_SortingGroupSortingCategory_sortingCategory_SortingCategoryId",
                        column: x => x.SortingCategoryId,
                        principalTable: "sortingCategory",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SortingGroupSortingCategory_SortingGroups_SortingGroupId",
                        column: x => x.SortingGroupId,
                        principalTable: "SortingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SortingGroupSortingCategory_SortingCategoryId",
                table: "SortingGroupSortingCategory",
                column: "SortingCategoryId");
        }
    }
}
