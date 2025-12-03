using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class EmpCopy
{
    public decimal EmpNo { get; set; }

    public string Cognom { get; set; } = null!;

    public string? Ofici { get; set; }

    public decimal? Cap { get; set; }

    public DateTime? DataAlta { get; set; }

    public decimal? Salari { get; set; }

    public decimal? Comissio { get; set; }

    public decimal DeptNo { get; set; }

    public virtual EmpCopy? CapNavigation { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Dept DeptNoNavigation { get; set; } = null!;

    public virtual ICollection<EmpCopy> InverseCapNavigation { get; set; } = new List<EmpCopy>();
}
