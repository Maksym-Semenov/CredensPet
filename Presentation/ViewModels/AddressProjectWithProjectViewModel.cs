namespace Presentation.ViewModels;

public class AddressProjectWithProjectViewModel
{
    public IQueryable<AddressProjectViewModel> ListAddressProjectProperties { get; set; }
    public IQueryable<ProjectViewModel> ListProjectProperties { get; set; }

}