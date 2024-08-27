namespace PhiloWellnessMVC.Models.WellnessModels
{
    public class WellnessDetailViewModel
    {
        public string? WellnessId { get; set; }
        public string UserId { get; set; }
        public int SelfRating { get; set; } // 1-20 scale
        public int FacultyRating { get; set; } // 1-20 scale
        public string? IncidentNotes { get; set; }
        public DateTime Date { get; set; }
    }
}
