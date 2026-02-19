using Microsoft.EntityFrameworkCore;
using Spedia.DataBaseModels;

namespace Spedia.DataBaseContext
{
    public class SpediaContext : DbContext
    {
        public SpediaContext()
        {
        }

        public SpediaContext(DbContextOptions<SpediaContext> options)
            : base(options)
        {
        }

        public DbSet<StudentTB> StudentTBs { get; set; }
        public DbSet<LevelTB> LevelTBs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTB>(e =>
            {
                e.HasKey(e => e.StudentId);
                e.Property(e => e.StudentName).IsRequired().HasMaxLength(50);
                e.Property(e=> e.StudentEmail).IsRequired().HasMaxLength(50);
                e.Property(e => e.StudentPass).IsRequired();
                e.Property(e=>e.StudentImage).IsRequired(false);
            });

            modelBuilder.Entity<LevelTB>(l =>
            {
                l.HasKey(l => l.LevelId);
                l.Property(l => l.LevelName).IsRequired();

            });
        }
    }
}
