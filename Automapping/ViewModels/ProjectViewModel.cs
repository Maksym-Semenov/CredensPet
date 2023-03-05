namespace Presentation.ViewModels;

public class ProjectViewModel
{
    public int ProjectId { get; set; }
    public int OrderValue { get; set; }
    public int OrderMonth { get; set; }
    public int OrderYear { get; set; }
    public int Price { get; set; }
    public string? OrderName { get; set; }
    public string? City { get; set; }

}