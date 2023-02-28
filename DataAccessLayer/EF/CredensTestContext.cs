using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF;

public partial class CredensTestContext : DbContext
{
    public CredensTestContext()
    {
    }

    public CredensTestContext(DbContextOptions<CredensTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAX-PC;Database=CredensTest;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.Property(e => e.BranchId).ValueGeneratedNever();
            entity.Property(e => e.IsOpen).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(1);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.BuildingNumber).HasMaxLength(50);
            entity.Property(e => e.BuildingPart).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Lit).HasMaxLength(50);
            entity.Property(e => e.ResidentialComplex).HasMaxLength(1);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TypeStreet).HasMaxLength(1);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.ProjectId).ValueGeneratedNever();
            entity.Property(e => e.BranchId).HasMaxLength(50);
            entity.Property(e => e.BuildingNumber).HasMaxLength(50);
            entity.Property(e => e.BuildingPart).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Litera).HasMaxLength(50);
            entity.Property(e => e.ManagerId).HasMaxLength(50);
            entity.Property(e => e.OrderMonth).HasMaxLength(50);
            entity.Property(e => e.OrderName).HasMaxLength(50);
            entity.Property(e => e.OrderValue).HasMaxLength(50);
            entity.Property(e => e.ResidentialComplex).HasMaxLength(1);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TypeStreet).HasMaxLength(1);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.UserRoleId).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
