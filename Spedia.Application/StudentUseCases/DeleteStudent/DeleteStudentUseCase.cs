using Spedia.Application.StandardResponse;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;

namespace Spedia.EndPoints.StudentEndPoints.DeleteStudent
{
    public class DeleteStudentUseCase
    {
        private readonly IStudentService IStudent;
        public DeleteStudentUseCase(IStudentService IStudent)
        {
            this.IStudent = IStudent;   
        }

        public async Task<DeleteStudentResponse> DeleteStudentAsync(int id)
        {
            var student =await IStudent.GetStudentByID(id);
            if(student != null)
            {
                await IStudent.Delete(student);
                return new DeleteStudentResponse
                {
                    ErrorCode = (int)ErrorCodeResponse.Success,
                    IsSuccess = true,
                    Message = "تم مسح الطالب",
                    Data = null
                };
            }
            else
            {
                return new DeleteStudentResponse
                {
                    // 105 => ID Not Found
                    ErrorCode = (int)ErrorCodeResponse.StudentIDNotFound,
                    IsSuccess = false,
                    Message = "هذا الطالب غير موجود",
                    Data = null
                };
            }
            
        }
    }
}
