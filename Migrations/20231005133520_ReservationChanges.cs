using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class ReservationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_BookId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_ClientId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservation",
                newName: "LivroId");

            migrationBuilder.AlterColumn<bool>(
                name: "ContractStatus",
                table: "Supplier",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_LivroId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_CustomerId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_LivroId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "LivroId",
                table: "Reservation",
                newName: "ReservationId");

            migrationBuilder.AlterColumn<string>(
                name: "ContractStatus",
                table: "Supplier",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservation",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservation",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Book_BookId",
                table: "Reservation",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_ClientId",
                table: "Reservation",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
