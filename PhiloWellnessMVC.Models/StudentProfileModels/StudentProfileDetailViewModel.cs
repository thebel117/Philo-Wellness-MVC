using PhiloWellnessMVC.Models.VisitModels;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileDetailViewModel
    {
        public string StudentProfileId { get; set; }
        public string UserId { get; set; }
        required public string Name { get; set; }
        public int Grade { get; set; }
        public string StudentIdNumber { get; set; }
        public List<VisitIndexViewModel>? Visits { get; set; }
        public List<WellnessIndexViewModel>? WellnessRecords { get; set; }
    }
}
