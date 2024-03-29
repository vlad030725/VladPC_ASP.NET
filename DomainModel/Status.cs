﻿using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Custom> Customs { get; set; } = new List<Custom>();
}
