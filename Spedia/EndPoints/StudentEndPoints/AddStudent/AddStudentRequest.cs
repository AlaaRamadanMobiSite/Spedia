namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class AddStudentRequest
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPass { get; set; } = string.Empty;
        public int LevelId { get; set; }
        public IFormFile? StudentImage { get; set; } 
    }
}
