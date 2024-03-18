using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class PromoCode
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public double Discount { get; set; }

    public virtual ICollection<Custom> Customs { get; set; } = new List<Custom>();
}
