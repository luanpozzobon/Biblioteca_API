﻿// <auto-generated />
using System;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca_API.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    partial class BibliotecaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Biblioteca_API.models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishingCompany")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Biblioteca_API.models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BorrowedBookCount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Owing")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Biblioteca_API.models.EditoraAfiliada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("autores")
                        .HasColumnType("TEXT");

                    b.Property<string>("contato")
                        .HasColumnType("TEXT");

                    b.Property<int>("qtdLivrosPublicados")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("EditorasAfiliadas");
                });

            modelBuilder.Entity("Biblioteca_API.models.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dataDeDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dataDeEmprestimo")
                        .HasColumnType("TEXT");

                    b.Property<int>("livroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pessoaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("status")
                        .HasColumnType("TEXT");

                    b.Property<double>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("livroId");

                    b.HasIndex("pessoaId");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("Biblioteca_API.models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantBook")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantEmployees")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Library");
                });

            modelBuilder.Entity("Biblioteca_API.models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Biblioteca_API.models.StudyRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoomNumber");

                    b.ToTable("StudyRoom");
                });

            modelBuilder.Entity("Biblioteca_API.models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ContractEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ContractStart")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ContractStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Biblioteca_API.models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("Biblioteca_API.models.Emprestimo", b =>
                {
                    b.HasOne("Biblioteca_API.models.Book", "livro")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_API.models.Client", "pessoa")
                        .WithMany()
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livro");

                    b.Navigation("pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
