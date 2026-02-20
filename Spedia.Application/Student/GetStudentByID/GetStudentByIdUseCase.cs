using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.Student.GetStudentByID
{
    public class GetStudentByIdUseCase
    {
        private readonly IStudentService Studentservice;
        public GetStudentByIdUseCase(IStudentService Studentservice)
        {
                this.Studentservice = Studentservice;
        }

        public async Task<GetStudentByIDResponse?> GetStudentByIDAsync (GetStudentByIDRequest request)
        {
            var student =await Studentservice.GetStudentByID(request.Id);
            if (student == null) return null;

            return new GetStudentByIDResponse
                {
                    StudentName = student.StudentName,
                    LevelId = student.LevelId,  
                    StudentEmail = student.StudentEmail,
                    StudentId = student.StudentId,  
                    StudentImage = student.StudentImage,    
                    StudentPass = student.StudentPass   
                    
                };
            
        }
    }
}
