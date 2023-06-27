using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class ProjectViewModel
{
    public string Id { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; } = DateTime.Now.ToString("MM");

    public string? OrderYear { get; set; } = DateTime.Now.ToString("yy");

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public string? CustomerId { get; set; }

    public string? ManagerId { get; set; }

    public string? MakerId { get; set; }

    public string? BranchId { get; set; }

    public string? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public string UserId { get; set; }

}