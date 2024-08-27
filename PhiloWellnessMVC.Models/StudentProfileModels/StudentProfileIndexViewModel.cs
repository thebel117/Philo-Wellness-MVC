namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileIndexViewModel
    {
        required public string StudentProfileId { get; set; }
        public string? Name { get; set; }
        public int Grade { get; set; }
        public string? StudentIdNumber { get; set; }
    }
}
