using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QFeedMill.Migrations
{
    /// <inheritdoc />
    public partial class AddedFeedCategorytoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedCategory_BirdCategoryId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FeedCategory");

            migrationBuilder.RenameColumn(
                name: "BirdCategoryId",
                table: "Feeds",
                newName: "FeedCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_BirdCategoryId",
                table: "Feeds",
                newName: "IX_Feeds_FeedCategoryId");

            migrationBuilder.CreateTable(
                name: "FeedCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedCategories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedCategories_FeedCategoryId",
                table: "Feeds",
                column: "FeedCategoryId",
                principalTable: "FeedCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedCategories_FeedCategoryId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FeedCategories");

            migrationBuilder.RenameColumn(
                name: "FeedCategoryId",
                table: "Feeds",
                newName: "BirdCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_FeedCategoryId",
                table: "Feeds",
                newName: "IX_Feeds_BirdCategoryId");

            migrationBuilder.CreateTable(
                name: "FeedCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedCategory", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedCategory_BirdCategoryId",
                table: "Feeds",
                column: "BirdCategoryId",
                principalTable: "FeedCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
