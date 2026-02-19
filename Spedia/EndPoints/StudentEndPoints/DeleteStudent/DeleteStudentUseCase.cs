using Spedia.EndPoints.StudentEndPoints.StudentContextService;

namespace Spedia.EndPoints.StudentEndPoints.DeleteStudent
{
    public class DeleteStudentUseCase
    {
        private readonly IStudentContext IStudent;
        public DeleteStudentUseCase(IStudentContext IStudent)
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
                    Success = true,
                    Message = "تم مسح الطالب"
                };
            }
            else
            {
                return new DeleteStudentResponse
                {
                    Success = false,
                    Message = "هذا الطالب غير موجود"
                };
            }
            
        }
    }
}
