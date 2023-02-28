namespace DataAccessLayer.Models;

public partial class Project
{
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

    public string? ManagerId { get; set; }

    public int? MakerId { get; set; }

    public string? BranchId { get; set; }
}
