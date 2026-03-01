using Spedia.Domain.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Domain.IServices
{
    public interface IStudentFatherService
    {
        Task AddStudentFather(StudentFather studentFather);
    }
}
