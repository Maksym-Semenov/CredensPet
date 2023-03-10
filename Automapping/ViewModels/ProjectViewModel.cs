namespace Presentation.ViewModels;

public class ProjectViewModel
{
    public int ProjectId { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; }

    public int? OrderYear { get; set; }

    public int? CustomerId { get; set; }

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    

    public int? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }

    public int UserId { get; set; }

    public int? MediatorId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastUpdated { get; set; }

}