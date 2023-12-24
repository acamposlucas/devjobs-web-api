using devjobs_web_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace devjobs_web_api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Requirements> Requirements { get; set; }
    public DbSet<RequirementsItem> RequirementsItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleItem> RoleItems { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>()
            .HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .IsRequired();

        modelBuilder.Entity<Job>()
            .HasOne(e => e.Requirements)
            .WithOne(e => e.Job)
            .HasForeignKey<Requirements>(e => e.JobId)
            .IsRequired();

        modelBuilder.Entity<Requirements>()
            .HasMany(e => e.Items)
            .WithOne(e => e.Requirements)
            .HasForeignKey(e => e.RequirementsId)
            .IsRequired();

        modelBuilder.Entity<Job>()
            .HasOne(e => e.Role)
            .WithOne(e => e.Job)
            .HasForeignKey<Role>(e => e.JobId)
            .IsRequired();

        modelBuilder.Entity<Role>()
            .HasMany(e => e.Items)
            .WithOne(e => e.Role)
            .HasForeignKey(e => e.RoleId)
            .IsRequired();

        modelBuilder.Entity<Contract>();
    }
}
