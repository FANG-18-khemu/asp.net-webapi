using System;
using System.Collections.Generic;

namespace employeeManagement.Models.EF;

public partial class DeptInfo
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }

    public string? DeptLocation { get; set; }

    public virtual ICollection<EmpInfo> EmpInfos { get; set; } = new List<EmpInfo>();
}
