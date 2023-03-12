using CredensPet.Infrastructure.DTO;

namespace Presentation.ViewModels;

public class UserViewModel
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserRoleId { get; set; }

    public int? RoleId { get; set; }


    public string BranchName { get; set; }
    public int ContactUserId { get; set; }
    //public ContactUserDTO ContactUserDto { get; set; }
}