using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Migrations
{
    public partial class NewOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "NewOption",
                columns: table => new
                {
                    SortingCategoryId = table.Column<int>(nullable: false),
                    SortingGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOption", x => new { x.SortingCategoryId, x.SortingGroupId });
                    table.ForeignKey(
                        name: "FK_NewOption_sortingCategory_SortingCategoryId",
                        column: x => x.SortingCategoryId,
                        principalTable: "sortingCategory",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewOption_SortingGroups_SortingGroupId",
                        column: x => x.SortingGroupId,
                        principalTable: "SortingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewOption_SortingGroupId",
                table: "NewOption",
                column: "SortingGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewOption");

            migrationBuilder.CreateTable(
                name: "NewOptions",
                columns: table => new
                {
                    SortingCategoryId = table.Column<int>(nullable: false),
                    SortingGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOptions", x => new { x.SortingCategoryId, x.SortingGroupId });
                    table.ForeignKey(
                        name: "FK_NewOptions_sortingCategory_SortingCategoryId",
                        column: x => x.SortingCategoryId,
                        principalTable: "sortingCategory",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewOptions_SortingGroups_SortingGroupId",
                        column: x => x.SortingGroupId,
                        principalTable: "SortingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewOptions_SortingGroupId",
                table: "NewOptions",
                column: "SortingGroupId");
        }
    }
}
