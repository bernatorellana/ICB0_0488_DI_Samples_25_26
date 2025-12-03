using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Comandum
{
    public decimal ComNum { get; set; }

    public DateTime? ComData { get; set; }

    public string? ComTipus { get; set; }

    public decimal ClientCod { get; set; }

    public DateTime? DataTramesa { get; set; }

    public decimal? Total { get; set; }

    public virtual Client ClientCodNavigation { get; set; } = null!;

    public virtual ICollection<Detall> Detalls { get; set; } = new List<Detall>();
}
