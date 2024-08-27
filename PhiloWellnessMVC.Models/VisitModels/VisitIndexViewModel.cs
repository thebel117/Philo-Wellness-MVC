namespace PhiloWellnessMVC.Models.VisitModels
{
    public class VisitIndexViewModel
    {
        public int VisitId { get; set; }
        public string? UserId { get; set; }
        public DateTime VisitDate { get; set; }
        public string? ReasonForVisit { get; set; }
    }
}
