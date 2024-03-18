using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsSale { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public int? IdCompany { get; set; }

    public int? IdTypeProduct { get; set; }

    public int? CountCores { get; set; }

    public int? CountStreams { get; set; }

    public int? Frequency { get; set; }

    public int? IdSocket { get; set; }

    public int? CountMemory { get; set; }

    public int? IdTypeMemory { get; set; }

    public int? IdFormFactor { get; set; }

    public virtual ICollection<CustomRow> CustomRows { get; set; } = new List<CustomRow>();

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual FormFactor? IdFormFactorNavigation { get; set; }

    public virtual Socket? IdSocketNavigation { get; set; }

    public virtual TypeMemory? IdTypeMemoryNavigation { get; set; }

    public virtual TypeProduct? IdTypeProductNavigation { get; set; }

    public virtual ICollection<ProcurementRow> ProcurementRows { get; set; } = new List<ProcurementRow>();
}
