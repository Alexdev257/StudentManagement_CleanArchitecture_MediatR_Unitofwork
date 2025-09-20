using Microsoft.EntityFrameworkCore;
using SM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FullName).IsRequired();
                b.Property(x => x.Email).IsRequired();
            });


            modelBuilder.Entity<Course>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired();
            });


            // Many-to-many
            modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students);
        }
    }
}
