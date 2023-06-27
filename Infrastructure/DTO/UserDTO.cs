namespace CredensPet.Infrastructure.DTO;

public class UserDTO
{
    public string Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserRoleId { get; set; }

    public string? RoleId { get; set; }

    public int? UserCount { get; set; }

    public string? ManagerId { get; set; }

    public string? CustomerId { get; set; }

    public string? MediatorId { get; set; }

    public string? MakerId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public string BranchId { get; set; }


}