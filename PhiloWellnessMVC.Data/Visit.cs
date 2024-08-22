using System;
using System.Collections.Generic;

namespace PhiloWellnessMVC.Data;

public partial class Visit
{
    public int VisitId { get; set; }

    public int? UserId { get; set; }

    public DateTime VisitDate { get; set; }

    public string ReasonForVisit { get; set; } = null!;

    public string? DetailedReason { get; set; }

    //public virtual User? User { get; set; }
}
