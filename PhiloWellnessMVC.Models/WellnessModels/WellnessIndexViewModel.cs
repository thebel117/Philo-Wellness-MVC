namespace PhiloPhiloWellnessMVC.Models.WellnessModels
{
    public class WellnessIndexViewModel
    {
        public int WellnessId { get; set; }
        public string? UserName { get; set; }
        public int SelfRating { get; set; } // 1-20 scale
        public int FacultyRating { get; set; } // 1-20 scale
        public DateTime Date { get; set; }
    }
}
