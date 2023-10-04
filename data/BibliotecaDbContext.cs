using Biblioteca_API.models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.data;

public class BibliotecaDbContext : DbContext {
    public DbSet<StudyRoom>? StudyRoom {get; set;}
    public DbSet<Supplier> Supplier { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("datasource=biblioteca.db; Cache=shared");
    }
}