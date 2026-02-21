using Spedia.Application.Student.UpdateStudent;
using Spedia.EndPoints.StudentEndPoints.AddStudent;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using Spedia.UploadFiles;
using static FastEndpoints.Ep;

namespace Spedia.EndPoints.StudentEndPoints.UpdateStudent
{
    public class UpdateStudentUseCase
    {
        private readonly IStudentService IStudent;
        private readonly IUploadImage uploadImage;
        public UpdateStudentUseCase(IStudentService IStudent , IUploadImage uploadImage)
        {
            this.IStudent = IStudent;
            this.uploadImage = uploadImage; 
        }

        public async Task<UpdateStudentResponse> UpdateStudentAsync(UpdatStudentRequest request)
        {
            var student = await IStudent.GetStudentByID(request.StudentId);

            if(student == null)
            {
                return new UpdateStudentResponse
                {
                    StausCode = 404,
                    Message = "هذا الطالب غير موجود",
                    IsSuccess = false,
                    Data = null
                };   
            }

            var domain = new StudentDomainModel
                (student.StudentName, student.StudentEmail , student.StudentPass ,student.StudentImage, student.LevelId);
            var studentImagePath = "";
            if (request.StudentImage != null)
                studentImagePath = uploadImage.post_file(request.StudentImage);

            domain.UpdateStudent(request.StudentName, request.StudentEmail, request.StudentPass, studentImagePath, request.LevelId);

            var hashPass = BCrypt.Net.BCrypt.HashPassword(domain.StudentPass);
            student.StudentName = domain.StudentName;
            student.StudentEmail = domain.StudentEmail;
            student.StudentPass = hashPass;
            student.LevelId = domain.LevelId;
            student.StudentImage = studentImagePath;

            await IStudent.UpdateStudent(student);
            return new UpdateStudentResponse
            {
                StausCode = 200,
                Message = "تم التعديل بنجاح",
                IsSuccess = true,
                Data = new UpdateStudentDto
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    LevelId = student.LevelId,
                    StudentEmail = domain.StudentEmail,
                    StudentPass = hashPass,
                    StudentImage = studentImagePath,
                }
            };


        }
    }
}
