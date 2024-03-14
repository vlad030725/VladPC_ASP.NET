using System;
using System.Collections.Generic;

namespace DAL;

public partial class Custom
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdStatus { get; set; }

    public int? IdPromoCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Sum { get; set; }

    public virtual ICollection<CustomRow> CustomRows { get; set; } = new List<CustomRow>();

    public virtual PromoCode? IdPromoCodeNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
