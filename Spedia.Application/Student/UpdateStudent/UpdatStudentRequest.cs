using Microsoft.AspNetCore.Http;

namespace Spedia.EndPoints.StudentEndPoints.UpdateStudent
{
    public class UpdatStudentRequest
    {
        public int StudentId { get; set; } 
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentPass { get; set; }
        public int LevelId { get; set; }
        public IFormFile? StudentImage { get; set; }

    }
}
