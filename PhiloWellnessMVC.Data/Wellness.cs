using System;
using System.Collections.Generic;

namespace PhiloWellnessMVC.Data;

public partial class WellnessRating
{
    public int WellnessRatingId { get; set; }
    
    public int? UserId { get; set; }

    public int SelfRating { get; set; }

    public int FacultyRating { get; set; }

    public string? Incidents { get; set; }

    public DateTime Date { get; set; }

    //public virtual User? User { get; set; }
}
