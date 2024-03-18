using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Socket
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
