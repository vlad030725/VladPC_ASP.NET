using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Procurement
{
    public int Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Sum { get; set; }

    public virtual ICollection<ProcurementRow> ProcurementRows { get; set; } = new List<ProcurementRow>();
}
