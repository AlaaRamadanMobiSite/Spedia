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

        public async Task<GetStudentByIDResponse> GetStudentByIDAsync (GetStudentByIDRequest request)
        {
            var student =await Studentservice.GetStudentByID(request.Id);
            if (student == null)
            {
                return new GetStudentByIDResponse
                {
                    // 105 => ID Not Found
                    ErrorCode = 105,
                    Message = "هذا الطالب غير موجود",
                    IsSuccess = false,
                    Data = null,
                };
            }
            else
            {
                return new GetStudentByIDResponse
                {
                    ErrorCode = 0,
                    Message = "هذا الطالب  موجود",
                    IsSuccess = true,
                    Data = new GetStudentByIdDto
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        LevelId = student.LevelId,
                        StudentEmail = student.StudentEmail,
                        StudentImage = student.StudentImage,
                        StudentPass = student.StudentPass   
                    },
                };
            }

        }
    }
}
