using System;
using System.Collections.Generic;

namespace EF_data_first.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Stname { get; set; }

    public string? Course { get; set; }
}
