using System;
using System.Collections.Generic;

namespace PhiloWellnessMVC.Data;

public partial class StudentProfile
{
    public int StudentProfileId { get; set; }

    public int? UserId { get; set; }

    public int? Grade { get; set; }

    public string? StudentIdNumber { get; set; }

    public virtual User? User { get; set; }
}
