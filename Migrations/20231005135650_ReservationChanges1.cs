using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class ReservationChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_LivroId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_CustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_LivroId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "LivroId",
                table: "Reservation",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservation",
                newName: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Reservation",
                newName: "LivroId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Reservation",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LivroId",
                table: "Reservation",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Book_LivroId",
                table: "Reservation",
                column: "LivroId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
