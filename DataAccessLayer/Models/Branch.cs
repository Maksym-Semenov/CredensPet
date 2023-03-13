using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

public partial class Branch
{
    [Key]
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public string? Phone { get; set; }

    public bool? IsOpen { get; set; }

    public List<Branch>? ListBranches { get; set; }

    public IEnumerable<Branch>? BranchesList { get; set; }


    public virtual ICollection<User> Users { get; } = new List<User>();
}
