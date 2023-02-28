using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? IsOpen { get; set; }
}
