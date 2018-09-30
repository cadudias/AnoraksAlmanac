using AnoraksAlmanacModel;
using Microsoft.EntityFrameworkCore;

namespace AnoraksAlmanacDAL
{
    public class AnoraksAlmanacContext : DbContext
    {
        public DbSet<Movie> Movies
        {
            get; set;
        }

        public AnoraksAlmanacContext(DbContextOptions<AnoraksAlmanacContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}