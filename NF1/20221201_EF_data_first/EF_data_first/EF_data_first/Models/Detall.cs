using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Detall
{
    public decimal ComNum { get; set; }

    public decimal DetallNum { get; set; }

    public decimal ProdNum { get; set; }

    public decimal? PreuVenda { get; set; }

    public decimal? Quantitat { get; set; }

    public decimal? Import { get; set; }

    public virtual Comandum ComNumNavigation { get; set; } = null!;

    public virtual Producte ProdNumNavigation { get; set; } = null!;
}
