using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.StudentFatherUseCases.AddStudentFather
{
    public class AddFatherDto
    {
        public string StudentFatherName { get;  set; } = string.Empty;
        public string StudentFatherEmail { get;  set; } = string.Empty;
        public string StudentFatherPassword { get;  set; } = string.Empty;
        public string StudentFatherPhone { get;  set; } = string.Empty;
        public int StudentId { get;  set; }
        
    }
}
