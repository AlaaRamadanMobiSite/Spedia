using Spedia.Application.StandardResponse;
using Spedia.Application.Student.AddStudent;
using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using Spedia.UploadFiles;

namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class StudentUseCase
    {
        private readonly IStudentService IStudent;
        private readonly IUploadImage uploadImage;
        public StudentUseCase (IStudentService IStudent , IUploadImage uploadImage)
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

            var studentEmailExist = await IStudent.GetStudentByEmail(request.StudentEmail);
            var studentNameExist = await IStudent.GetStudentByName(request.StudentName);
            if (studentNameExist != null)
            {
                return new AddStudentResponse()
                {
                    // 101 => Name Exist
                    ErrorCode = (int)ErrorCodeResponse.StudentNameExist,
                    Message = "هذا الاسم موجود",
                    IsSuccess = false,
                    Data =null
                };
            }
            else if(studentEmailExist != null)
            {
                return new AddStudentResponse()
                {
                    // 107 => Email Exist
                    ErrorCode = (int)ErrorCodeResponse.StudentEmailExist,
                    Message = "هذا الايميل موجود",
                    IsSuccess = false,
                    Data = null
                };
            }
            else
            {
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
                    ErrorCode = (int)ErrorCodeResponse.Success,
                    Message = "تمت الاضافه بنجاح",
                    IsSuccess = true,
                    Data = new AddStudentDto
                    {
                        StudentName = student.StudentName,
                        StudentEmail = student.StudentEmail,
                        StudentPass = hashPass,
                        LevelId = student.LevelId,
                    }
                };
            }
        }
    }
}
