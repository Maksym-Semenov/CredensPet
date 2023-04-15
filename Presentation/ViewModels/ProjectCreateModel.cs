using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels
{
    public class ProjectCreateModel
    {
        public ProjectViewModel Project { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
