using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Project
{
    [Key]
    public int ProjectId { get; set; }

    public string? OrderValue { get; set; }

    public string? OrderMonth { get; set; }

    public int? OrderYear { get; set; }

    public int? CustomerId { get; set; }

    public string? OrderName { get; set; }

    public double? Price { get; set; }

    public string? City { get; set; }

    public string? ResidentialComplex { get; set; }

    public string? TypeStreet { get; set; }

    public string? Street { get; set; }

    public string? BuildingNumber { get; set; }

    public string? Litera { get; set; }

    public string? BuildingPart { get; set; }

    public int? Apartment { get; set; }

    public string? Floor { get; set; }

    public int? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }

    public int UserId { get; set; }

    public int? MediatorId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual ContactProject? ContactProject { get; set; }

    public virtual User User { get; set; } = null!;
}
