namespace Presentation.ViewModels;

public class ProjectUserBranchViewModel
{
    public IQueryable<UserViewModel>? ListUserProperties { get; set; }
    public IQueryable<BranchViewModel>? ListBranchProperties { get; set; }
    public IQueryable<ProjectViewModel>? ListProjectProperties { get; set; }

}