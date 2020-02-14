namespace Andreys.Data
{
    using Andreys.App.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class AndreysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-IN4GT0T\SQLEXPRESS;Database=Andreys;Integrated Security=true;");
        }
    }
}
