using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models;

[Table("Users"), Display(Name = "Користувач")]
public partial class User : IdentityUser<Guid>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50), Display(Name = "Ім'я")]
    public string? FirstName { get; set; }

    [StringLength(50), Display(Name = "По-батькові")]
    public string? MiddleName { get; set; }

    [StringLength(50), Display(Name = "Прізвище")]
    public string? LastName { get; set; }

    [ForeignKey(nameof(UserRoleId)), Display(Name = "ID Ролі")]
    public Guid? UserRoleId { get; set; }

    public Guid? RoleId { get; set; }

    public int? UserCount { get; set; }

    [ForeignKey(nameof(ManagerId)), Display(Name = "Менеджер")]
    public Guid? ManagerId { get; set; }

    [ForeignKey(nameof(CustomerId)), Display(Name = "Покупець")]
    public Guid? CustomerId { get; set; }

    [ForeignKey(nameof(MediatorId)), Display(Name = "Посередник")]
    public Guid? MediatorId { get; set; }

    [ForeignKey(nameof(MakerId)), Display(Name = "Збиральник")]
    public Guid? MakerId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Created { get; set; } = default(DateTime);

    public DateTime? LastUpdated { get; set; }

    [ForeignKey(nameof(Branch)), Display(Name = "Філія")]
    public Guid BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ContactUser? ContactsUser { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();

   
}
