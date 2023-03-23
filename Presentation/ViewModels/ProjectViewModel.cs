using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class ProjectViewModel
{
    public int ProjectId { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; } = DateTime.Now.ToString("MM");

    public string? OrderYear { get; set; } = DateTime.Now.ToString("yy");

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public int? CustomerId { get; set; }

    public int? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }

    public int? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public int UserId { get; set; }

}