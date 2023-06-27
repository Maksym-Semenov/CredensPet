using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Project
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? OrderValue { get; set; }
    
    public string? OrderMonth { get; set; } = DateTime.Now.ToString("d");

    public string? OrderYear { get; set; } = DateTime.Now.ToString("D");

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public string? CustomerId { get; set; }

    public string? ManagerId { get; set; }

    public string? MakerId { get; set; }

    public string? BranchId { get; set; }

    public string? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;



    public virtual AddressProject? AddressProject { get; set; }

    public string UserId { get; set; } = Guid.NewGuid().ToString();

    public virtual User User { get; set; } = null!;
}
