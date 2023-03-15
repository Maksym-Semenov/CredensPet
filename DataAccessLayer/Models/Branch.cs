using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Branch
{
    [Key]
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public string? Phone { get; set; }

    public bool? IsOpen { get; set; }


    public virtual ICollection<User> Users { get; } = new List<User>();
}
