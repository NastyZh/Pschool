using Microsoft.EntityFrameworkCore;
using PschoolFrontEnd.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Parent>? Parents { get; set; }
    public DbSet<Student>? Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Parent>()
            .HasMany(p => p.Children)
            .WithOne()
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.Cascade);  
    }
}