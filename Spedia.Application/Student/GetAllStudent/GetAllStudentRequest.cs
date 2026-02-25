using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.Student.GetAllStudent
{
    public class GetAllStudentRequest
    {
        public int PageNumber { get; set; } = 1;
        public int RowCount { get; set; } = 10;
    }
}
