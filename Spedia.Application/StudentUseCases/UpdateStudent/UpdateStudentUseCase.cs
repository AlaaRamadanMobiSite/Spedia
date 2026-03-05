using Spedia.Application.StandardResponse;
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
                    // 105 => ID Not Found
                    ErrorCode = (int)ErrorCodeResponse.StudentIDNotFound,
                    Message = "هذا الطالب غير موجود",
                    IsSuccess = false,
                    Data = null
                };   
            }

            //var domain = new StudentDomainModel
            //    (student.StudentName, student.StudentEmail , student.StudentPass ,student.StudentImage, student.LevelId);
            var studentImagePath = student.StudentImage;
            if (request.StudentImage != null)
                studentImagePath = uploadImage.post_file(request.StudentImage);

            StudentDomainModel.UpdateStudent(request.StudentName, request.StudentEmail, request.StudentPass, studentImagePath, request.LevelId);

            var hashPass = student.StudentPass;
            if(request.StudentPass != null)
                BCrypt.Net.BCrypt.HashPassword(request.StudentPass);

           if(!string.IsNullOrWhiteSpace(request.StudentName)) student.StudentName = request.StudentName;
           if(!string.IsNullOrWhiteSpace(request.StudentEmail)) student.StudentEmail = request.StudentEmail;
            student.StudentPass = hashPass;
           if(request.LevelId != 0) student.LevelId = request.LevelId;
            student.StudentImage = studentImagePath;

            await IStudent.UpdateStudent(student);
            return new UpdateStudentResponse
            {
                ErrorCode = (int)ErrorCodeResponse.Success,
                Message = "تم التعديل بنجاح",
                IsSuccess = true,
                Data = new UpdateStudentDto
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    LevelId = student.LevelId,
                    StudentEmail = student.StudentEmail,
                    StudentPass = hashPass,
                    StudentImage = studentImagePath,
                }
            };


        }
    }
}
