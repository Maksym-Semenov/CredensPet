namespace Presentation.ViewModels;

public class ContactUserWithUserViewModel
{
    public IQueryable<ContactUserViewModel> ListContactUserProperties { get; set; }
    public IQueryable<UserViewModel> ListUserProperties { get; set; }

}