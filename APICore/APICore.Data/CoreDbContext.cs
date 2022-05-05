using APICore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICore.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Log> Log { get; set; } 
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}