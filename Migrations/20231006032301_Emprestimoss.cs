using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class Emprestimoss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDoEvento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorDoEvento = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantidadeDePessoa = table.Column<int>(type: "INTEGER", nullable: false),
                    Editora = table.Column<string>(type: "TEXT", nullable: true),
                    Livro = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
