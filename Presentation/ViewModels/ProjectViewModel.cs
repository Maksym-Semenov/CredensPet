using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class ProjectViewModel
{
    public Guid Id { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; }

    public string? OrderYear { get; set; }

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid? MakerId { get; set; }

    public Guid? BranchId { get; set; }

    public Guid? MediatorId { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public Guid UserId { get; set; }

}