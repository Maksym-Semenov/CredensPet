using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserRoleId { get; set; }

    public int? RoleId { get; set; }

    public int? UserCount { get; set; }

    public int? ManagerId { get; set; }

    public int? CustomerId { get; set; }

    public int? MediatorId { get; set; }

    public int? MakerId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ContactUser? ContactsUser { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
