using BoardsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardsService.Data
{
    public class BoardsDbContext: DbContext
    {
        public BoardsDbContext(DbContextOptions<BoardsDbContext> options): 
            base(options)
        {
            
           
        }
        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Project>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
