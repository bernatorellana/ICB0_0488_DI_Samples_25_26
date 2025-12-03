using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Dept
{
    public decimal DeptNo { get; set; }

    public string Dnom { get; set; } = null!;

    public string? Loc { get; set; }

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
