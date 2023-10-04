using Biblioteca_API.models;
using BIBLIOTECA_API.Models;
using Microsoft.EntityFrameworkCore;
public class BibliotecaDbContext : DbContext {

    public DbSet<>? exemplo {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.useSqlite("datasource=biblioteca.db; Cache=shared");
    }

    public DbSet<Emprestimo> Emprestimos { get; set;}
    public DbSet<EditoraAfiliada> EditorasAfiliadas{ get; set;}
}