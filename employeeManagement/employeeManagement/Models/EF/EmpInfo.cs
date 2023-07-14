using System;
using System.Collections.Generic;

namespace employeeManagement.Models.EF;

public partial class EmpInfo
{
    public int EmpNo { get; set; }

    public string? EmpName { get; set; }

    public string? EmpDesignation { get; set; }

    public int? EmpSalary { get; set; }

    public bool? EmpIsPresent { get; set; }

    public int? EmpDept { get; set; }

    public virtual DeptInfo? EmpDeptNavigation { get; set; }
}
