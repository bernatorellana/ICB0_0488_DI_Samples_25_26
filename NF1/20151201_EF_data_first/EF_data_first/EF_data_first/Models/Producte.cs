using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Producte
{
    public decimal ProdNum { get; set; }

    public string Descripcio { get; set; } = null!;

    public virtual ICollection<Detall> Detalls { get; set; } = new List<Detall>();
}
