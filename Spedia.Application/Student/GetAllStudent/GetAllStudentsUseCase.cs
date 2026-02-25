using Spedia.Application.StandardResponse;
using Spedia.Application.Student.GetAllStudent;
using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using System.Linq;

namespace Spedia.EndPoints.StudentEndPoints.GetAllStudents
{
    public class GetAllStudentsUseCase
    {
        private readonly IStudentService IStudent;
        public GetAllStudentsUseCase(IStudentService IStudent)
        {
            this.IStudent = IStudent;
        }

        public async Task<GetAllStudentResponse> GetAllStudentAsync(GetAllStudentRequest request)
        {
            var student =  await IStudent.GetAll();

            if(student == null)
            {
                return new GetAllStudentResponse
                {
                    // 108 => StudentList Null
                    ErrorCode = (int)ErrorCodeResponse.StudentListNull,
                    Message = "لا يوجد طلاب",
                    IsSuccess =false,
                    Data = null
                };
            }
            else
            {
                return new GetAllStudentResponse
                {
                    ErrorCode = (int)ErrorCodeResponse.Success,
                    Message = "الطلاب الموجوده",
                    IsSuccess = true,
                    Data = student.Select(e => new GetAllStudentDto
                    {
                        StudentId = e.StudentId,
                        StudentName = e.StudentName,
                        LevelId = e.LevelId,
                        StudentEmail = e.StudentEmail,
                        StudentImage = e.StudentImage,
                        StudentPass = e.StudentPass,
                    }).Skip((request.PageNumber - 1) * request.RowCount).Take(request.RowCount).ToList()
                };
            }
        }
    }
}
