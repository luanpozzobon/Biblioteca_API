using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class Emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Book_livroId",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Client_pessoaId",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Book_BookId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_ClientId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_livroId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_pessoaId",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dataDeEmprestimo",
                table: "Emprestimo",
                newName: "DataDeEmprestimo");

            migrationBuilder.RenameColumn(
                name: "dataDeDevolucao",
                table: "Emprestimo",
                newName: "DataDeDevolucao");

            migrationBuilder.RenameColumn(
                name: "pessoaId",
                table: "Emprestimo",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "livroId",
                table: "Emprestimo",
                newName: "BookId");

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
                name: "ClientId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservation",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "DataDeEmprestimo",
                table: "Emprestimo",
                newName: "dataDeEmprestimo");

            migrationBuilder.RenameColumn(
                name: "DataDeDevolucao",
                table: "Emprestimo",
                newName: "dataDeDevolucao");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Emprestimo",
                newName: "pessoaId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Emprestimo",
                newName: "livroId");

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
                name: "ClientId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Emprestimo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Emprestimo",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Client",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_livroId",
                table: "Emprestimo",
                column: "livroId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_pessoaId",
                table: "Emprestimo",
                column: "pessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Book_livroId",
                table: "Emprestimo",
                column: "livroId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Client_pessoaId",
                table: "Emprestimo",
                column: "pessoaId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
