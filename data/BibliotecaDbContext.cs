using Biblioteca_API.models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.data;

public class BibliotecaDbContext : DbContext {
    public DbSet<StudyRoom> StudyRoom {get; set;}
    public DbSet<Supplier> Supplier {get; set;}
    public DbSet<Emprestimo> Emprestimo {get; set;}
    public DbSet<EditoraAfiliada> EditorasAfiliadas { get; set;}
    public DbSet<Book> Book { get; set;}
    public DbSet<Client> Client {get; set;}
    public DbSet<Library> Library {get; set;}
    public DbSet<Reservation> Reservation{get; set;}
    public DbSet<Worker> Worker {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("datasource=biblioteca.db; Cache=shared");
    }

    
}