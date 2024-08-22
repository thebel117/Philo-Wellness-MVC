using System;

namespace PhiloWellnessMVC.Models.VisitModels
{
    public class VisitDetailViewModel
    {
        public int VisitId { get; set; }

        public int UserId { get; set; }

        public DateTime VisitDate { get; set; }

        public string? ReasonForVisit { get; set; }

        public string? DetailedReason { get; set; }

        public string? UserName { get; set; }
    }
}
