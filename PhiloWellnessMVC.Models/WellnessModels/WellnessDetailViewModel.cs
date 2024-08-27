namespace PhiloWellnessMVC.Models.WellnessModels
{
    public class WellnessDetailViewModel
    {
        public int WellnessId { get; set; }
        public int UserId { get; set; }
        public int SelfRating { get; set; } // 1-20 scale
        public int FacultyRating { get; set; } // 1-20 scale
        public string? IncidentNotes { get; set; }
        public DateTime Date { get; set; }
    }
}
