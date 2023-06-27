using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class ContactUserViewModel
{
    public string Id { get; set; }

    public string PhoneMain { get; set; } = string.Empty;

    public string? Phone2 { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? ResidentialComplex { get; set; }

    public string? TypeStreet { get; set; }

    public string? Street { get; set; }

    public string? BuildingNumber { get; set; }

    public string? Litera { get; set; }

    public string? BuildingPart { get; set; }

    public int? Apt { get; set; }

    public string? Floor { get; set; }

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? LastUpdated { get; set; } = DateTime.Now;


    public string UserId { get; set; }

}