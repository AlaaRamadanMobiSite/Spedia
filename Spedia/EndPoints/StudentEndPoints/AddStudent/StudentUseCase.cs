using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using Spedia.UploadFiles;

namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class StudentUseCase
    {
        private readonly IStudentContext IStudent;
        private readonly IUploadImage uploadImage;
        public StudentUseCase (IStudentContext IStudent , IUploadImage uploadImage)
        {
            this.IStudent = IStudent;
            this.uploadImage = uploadImage;
        }

        public async Task<AddStudentResponse> AddStudentAsync(AddStudentRequest request)
        {
            var studentImagePath = "";
            if(request.StudentImage != null)
                studentImagePath = uploadImage.post_file(request.StudentImage);

            var domain = new StudentDomainModel
                (request.StudentName , request.StudentEmail , request.StudentPass, studentImagePath, request.LevelId);

            var hashPass = BCrypt.Net.BCrypt.HashPassword(domain.StudentPass);

            var student = new StudentTB()
            {
                StudentName = domain.StudentName,
                StudentEmail = domain.StudentEmail,
                StudentPass = hashPass,
                LevelId = domain.LevelId,
                StudentImage = studentImagePath
            };

               await IStudent.AddStudent(student);
            return new AddStudentResponse()
            {
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                StudentPass = student.StudentPass,
                LevelId = student.LevelId,
            };
            
        }

    }
}
