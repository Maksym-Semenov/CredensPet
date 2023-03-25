namespace Presentation.ViewModels;

public class UserBranchViewModel
{
    public IQueryable<UserViewModel> ListUserProperties { get; set; }
    public IQueryable<BranchViewModel> ListBranchProperties { get; set; }

}