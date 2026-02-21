using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.Student.AddStudent
{
    public class AddStudentDto
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPass { get; set; } = string.Empty;
        public int LevelId { get; set; }
    }
}
