using Spedia.Application.Student.GetAllStudent;
using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;

namespace Spedia.EndPoints.StudentEndPoints.GetAllStudents
{
    public class GetAllStudentsUseCase
    {
        private readonly IStudentService IStudent;
        public GetAllStudentsUseCase(IStudentService IStudent)
        {
            this.IStudent = IStudent;
        }

        public async Task<GetAllStudentResponse> GetAllStudentAsync()
        {
            var student =  await IStudent.GetAll();

            if(student == null)
            {
                return new GetAllStudentResponse
                {
                    // 105 => ID Not Found
                    ErrorCode = 105,
                    Message = "لا يوجد طلاب",
                    IsSuccess =false,
                    Data = null
                };
            }
            else
            {
                return new GetAllStudentResponse
                {
                    ErrorCode = 0,
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
                    }).ToList()
                };
            }
        }
    }
}
