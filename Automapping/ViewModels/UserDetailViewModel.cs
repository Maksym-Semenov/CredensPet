using Presentation.ViewModels;

namespace Automapping.ViewModels;

public class UserDetailViewModel    
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public virtual List<ContactViewModel> Contacts { get; set; }
    public virtual List<ProjectViewModel> Projects { get; set; }
}