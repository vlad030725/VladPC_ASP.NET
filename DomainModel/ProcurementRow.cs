using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class ProcurementRow
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? IdProcurement { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public virtual Procurement? IdProcurementNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
