using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DomainModel;

public partial class User : IdentityUser<int>
{
    public string? Name { get; set; }

    public virtual ICollection<Custom> Customs { get; set; } = new List<Custom>();
}
