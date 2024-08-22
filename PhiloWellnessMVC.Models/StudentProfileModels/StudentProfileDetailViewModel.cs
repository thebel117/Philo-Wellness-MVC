using PhiloMVC.Models.VisitModels;
using PhiloMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileDetailViewModel
    {
        public int StudentProfileId { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public int Grade { get; set; }
        public string? StudentIdNumber { get; set; }
        public List<VisitIndexViewModel>? Visits { get; set; }
        public List<WellnessIndexViewModel>? WellnessRecords { get; set; }
    }
}
