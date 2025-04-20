using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Role
{
    public int Id { get; set; }

    public string RoleNameEn { get; set; } = null!;

    public string RoleNameAr { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
