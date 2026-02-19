using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;

namespace Spedia.EndPoints.StudentEndPoints.GetAllStudents
{
    public class GetAllStudentsUseCase
    {
        private readonly IStudentContext IStudent;
        public GetAllStudentsUseCase(IStudentContext IStudent)
        {
            this.IStudent = IStudent;
        }

        public async Task<List<GetAllStudentResponse>> GetAllStudentAsync()
        {
            var student =  await IStudent.GetAll();

            return student.Select(e=> new GetAllStudentResponse
            {
                StudentName = e.StudentName,
                StudentId = e.StudentId,
                LevelId = e.LevelId,
                StudentEmail = e.StudentEmail,
                StudentPass = e.StudentPass,
                StudentImage = e.StudentImage,
            }).ToList();
        }

    }
}
