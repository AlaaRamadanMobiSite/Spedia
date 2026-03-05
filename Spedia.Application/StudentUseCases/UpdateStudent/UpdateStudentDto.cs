using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.Student.UpdateStudent
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPass { get; set; } = string.Empty;
        public int LevelId { get; set; }
        public string StudentImage { get; set; } = string.Empty;
    }
}
