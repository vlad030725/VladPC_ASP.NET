﻿using System;
using System.Collections.Generic;

namespace DAL;

public partial class TypeMemory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
