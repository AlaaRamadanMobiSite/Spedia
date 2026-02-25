using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.StandardResponse
{
    public enum ErrorCodeResponse
    {
        Success = 0,
        StudentNameExist = 101,
        StudentNameRequired = 102,
        StudentName4Keyword = 103,
        StudentEmailRequired = 104,
        StudentIDNotFound = 105,
        StudentEmailCorrectly = 106,
        StudentEmailExist = 107,
        StudentListNull = 108,
    }
}
