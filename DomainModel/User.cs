using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Custom> Customs { get; set; } = new List<Custom>();
}
