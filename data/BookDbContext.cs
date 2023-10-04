using System.Runtime.InteropServices;
using Biblioteca_API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace Biblioteca_API.data
{


    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
    
        public DbSet<Book> Book {get;set;}

        public DbSet<Library> Library {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}