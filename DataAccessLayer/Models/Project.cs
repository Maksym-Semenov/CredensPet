using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Project
{
    [Key]
    public int ProjectId { get; set; }

    public string? OrderValue { get; set; }
    
    public string? OrderMonth { get; set; } = DateTime.Now.ToString("d");

    public string? OrderYear { get; set; } = DateTime.Now.ToString("D");

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public int? CustomerId { get; set; }

    public int? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }

    public int? MediatorId { get; set; }

    [DisplayFormat(DataFormatString = "{dd-MM-yyyy")]
    public DateTime? Created { get; set; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{dd-MM-yyyy")]
    public DateTime? LastUpdated { get; set; } = DateTime.Now;



    //public int ContactProjectId { get; set; }

    //public virtual ContactProject? ContactProject { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
