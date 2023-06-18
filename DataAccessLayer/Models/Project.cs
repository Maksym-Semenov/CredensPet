using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

public partial class Project
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? OrderValue { get; set; }
    
    public string? OrderMonth { get; set; }

    public string? OrderYear { get; set; }

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid? MakerId { get; set; }

    public Guid? BranchId { get; set; }

    public Guid? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;



    public virtual AddressProject? AddressProject { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
