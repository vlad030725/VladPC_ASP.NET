using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class CustomRow
{
    public int Id { get; set; }

    public int? IdCustom { get; set; }

    public int? IdProduct { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public virtual Custom? IdCustomNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
