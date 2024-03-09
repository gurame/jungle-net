using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Books.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: "Books");

    migrationBuilder.CreateTable(
        name: "Books",
        schema: "Books",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Books", x => x.Id);
        });

    migrationBuilder.InsertData(
        schema: "Books",
        table: "Books",
        columns: new[] { "Id", "Author", "Price", "Title" },
        values: new object[,]
        {
                  { new Guid("1904b531-53c9-4376-8da8-3122aa436801"), "J.R.R Tolkien", 11.99m, "The Two Towers" },
                  { new Guid("92b23a8e-f785-4918-8bc9-fd3fe2e7d9a8"), "J.R.R Tolkien", 12.99m, "The Return of the Ring" },
                  { new Guid("a590d3cc-0481-43aa-ae76-529b284d6fe0"), "J.R.R Tolkien", 10.99m, "The Fellowship of the Ring" }
        });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Books",
        schema: "Books");
  }
}
