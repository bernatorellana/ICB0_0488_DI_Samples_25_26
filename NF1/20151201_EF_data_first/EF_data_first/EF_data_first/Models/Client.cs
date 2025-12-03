using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Client
{
    public decimal ClientCod { get; set; }

    public string Nom { get; set; } = null!;

    public string Direccio { get; set; } = null!;

    public string Ciutat { get; set; } = null!;

    public string? Estat { get; set; }

    public string CodiPostal { get; set; } = null!;

    public decimal? Area { get; set; }

    public string? Telefon { get; set; }

    public int? ReprCod { get; set; }

    public decimal? LimitCredit { get; set; }

    public string? Observacions { get; set; }

    public virtual ICollection<Comandum> Comanda { get; set; } = new List<Comandum>();

    public virtual Emp? ReprCodNavigation { get; set; }
}
