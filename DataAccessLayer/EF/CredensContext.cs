using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.EF;

public partial class CredensContext : DbContext
{
    public CredensContext()
    {
    }

    public CredensContext(DbContextOptions<CredensContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<AddressProject> AddressProjects { get; set; }

    public virtual DbSet<ContactUser> ContactUsers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4JMLDIS;Database=CredensPet;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

public class CredensDbContextFactory : IDesignTimeDbContextFactory<CredensContext>
{
    public CredensContext CreateDbContext(string[] args)

    {
        var optionsBuilder = new DbContextOptionsBuilder<CredensContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-4JMLDIS;Database=CredensPet;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        return new CredensContext(optionsBuilder.Options);
    }
}
