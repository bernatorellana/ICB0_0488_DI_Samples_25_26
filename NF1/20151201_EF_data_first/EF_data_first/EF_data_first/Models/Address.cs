using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public int? Studentid { get; set; }

    public virtual Student? Student { get; set; }
}
