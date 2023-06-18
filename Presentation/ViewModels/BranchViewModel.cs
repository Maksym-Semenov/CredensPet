namespace Presentation.ViewModels;

public class BranchViewModel
{
    public Guid Id { get; set; }

    public string? BranchName { get; set; }

    public string? Phone { get; set; }

    public string? IsOpen { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;

}