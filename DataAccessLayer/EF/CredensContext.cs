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
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<ContactProject> ContactProjects { get; set; }

    public virtual DbSet<ContactsUser> ContactsUsers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseMySql("Server=db23.freehost.com.ua;Database=meblis2_credens;User=meblis2_zmey;Password=IwYyR0wnG;", ServerVersion.AutoDetect("Server=db23.freehost.com.ua;Database=meblis2_credens;User=meblis2_zmey;Password=IwYyR0wnG;"));
        => optionsBuilder.UseSqlServer("Server=MAX-PC;Database=CredensTest;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

}

//public class CredensDbContextFactory : IDesignTimeDbContextFactory<CredensContext> 
//{ public CredensContext CreateDbContext(string[] args) 

//    {
//        var optionsBuilder = new DbContextOptionsBuilder<CredensContext>(); 
//        optionsBuilder.UseSqlServer("Server=MAX-PC;Database=CredensTest;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"); 
//        return new CredensContext(optionsBuilder.Options);
//    }
//}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Branch>(entity =>
    //    {
    //        //entity.Property(e => e.BranchId).ValueGeneratedNever();
    //        entity.Property(e => e.IsOpen).HasMaxLength(1);
    //        entity.Property(e => e.Name).HasMaxLength(50);
    //        entity.Property(e => e.Phone).HasMaxLength(1);
    //    });

    //    modelBuilder.Entity<Contact>(entity =>
    //    {
    //        //entity.Property(e => e.ContactId).ValueGeneratedNever();
    //        entity.Property(e => e.BuildingNumber).HasMaxLength(50);
    //        entity.Property(e => e.BuildingPart).HasMaxLength(50);
    //        entity.Property(e => e.City).HasMaxLength(50);
    //        entity.Property(e => e.Floor).HasMaxLength(50);
    //        entity.Property(e => e.Lit).HasMaxLength(50);
    //        entity.Property(e => e.ResidentialComplex).HasMaxLength(1);
    //        entity.Property(e => e.Street).HasMaxLength(50);
    //        entity.Property(e => e.TypeStreet).HasMaxLength(1);
    //    });

    //    modelBuilder.Entity<Project>(entity =>
    //    {
    //        //entity.Property(e => e.BranchId).HasMaxLength(50);
    //        entity.Property(e => e.BuildingNumber).HasMaxLength(50);
    //        entity.Property(e => e.BuildingPart).HasMaxLength(50);
    //        entity.Property(e => e.City).HasMaxLength(50);
    //        entity.Property(e => e.Floor).HasMaxLength(50);
    //        entity.Property(e => e.Litera).HasMaxLength(50);
    //        entity.Property(e => e.ManagerId).HasMaxLength(50);
    //        entity.Property(e => e.OrderMonth).HasMaxLength(50);
    //        entity.Property(e => e.OrderName).HasMaxLength(50);
    //        entity.Property(e => e.OrderValue).HasMaxLength(50);
    //        entity.Property(e => e.ResidentialComplex).HasMaxLength(1);
    //        entity.Property(e => e.Street).HasMaxLength(50);
    //        entity.Property(e => e.TypeStreet).HasMaxLength(1);
    //    });

    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        //entity.Property(e => e.UserId).ValueGeneratedNever();
    //        entity.Property(e => e.FirstName).HasMaxLength(50);
    //        entity.Property(e => e.LastName).HasMaxLength(50);
    //        entity.Property(e => e.MiddleName).HasMaxLength(50);
    //        entity.Property(e => e.UserRoleId).HasMaxLength(50);
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

