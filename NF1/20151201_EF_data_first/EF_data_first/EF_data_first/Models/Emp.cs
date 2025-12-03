using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Emp
{
    public int EmpNo { get; set; }

    public string Cognom { get; set; } = null!;

    public string? Ofici { get; set; }

    public int? Cap { get; set; }

    public DateTime? DataAlta { get; set; }

    public decimal? Salari { get; set; }

    public decimal? Comissio { get; set; }

    public decimal DeptNo { get; set; }

    public virtual Emp? CapNavigation { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Dept DeptNoNavigation { get; set; } = null!;

    public virtual ICollection<Emp> InverseCapNavigation { get; set; } = new List<Emp>();
}
