namespace IRunes.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class RunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-IN4GT0T\SQLEXPRESS;Database=MusicStore;Integrated Security=true;");
        }
    }
}
