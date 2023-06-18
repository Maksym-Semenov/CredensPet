using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CredensPet.Infrastructure.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public Guid? UserRoleId { get; set; }

    public Guid? RoleId { get; set; }

    public int? UserCount { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? MediatorId { get; set; }

    public Guid? MakerId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public Guid BranchId { get; set; }


}