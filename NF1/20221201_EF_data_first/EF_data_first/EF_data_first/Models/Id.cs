using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Id
{
    public string TableName { get; set; } = null!;

    public decimal? LastId { get; set; }
}
