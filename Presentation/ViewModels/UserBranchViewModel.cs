
namespace Presentation.ViewModels;

public class UserBranchViewModel
{
    public IQueryable<UserViewModel> UsersBranches { get; set; }
    public IQueryable<BranchViewModel> BranchesUsers { get; set; }
}