namespace PhiloWellnessMVC.Models.WellnessModels
{
    public class WellnessIndexViewModel
    {
        public string? WellnessId { get; set; }
        public string? UserName { get; set; }
        public int SelfRating { get; set; } // 1-20 scale
        public int FacultyRating { get; set; } // 1-20 scale
        public string? IncidentNotes { get; set; }          //Forgot this and the Detail.cshtml(s) shat themselves --> reassess some of these naming conventions.
        public DateTime Date { get; set; }
    }
}
