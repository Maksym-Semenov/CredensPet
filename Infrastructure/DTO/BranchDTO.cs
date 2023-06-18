namespace CredensPet.Infrastructure.DTO;

public class BranchDTO
{
    public Guid Id { get; set; }

    public string? BranchName { get; set; }

    public string? Phone { get; set; }

    public bool? IsOpen { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;

}