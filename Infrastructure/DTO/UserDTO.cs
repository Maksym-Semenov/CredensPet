namespace CredensPet.Infrastructure.DTO;

public class UserDTO
{
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



    public int BranchId { get; set; }

    //public int ContactUserId { get; set; }

    //public ContactUserDTO ContactUserDto { get; set; }

}