using Spedia.DataBaseModels;

namespace Spedia.EndPoints.StudentEndPoints.StudentContextService
{
    public interface IStudentService
    {
        Task AddStudent(StudentTB studentTB);
        Task<List<StudentTB>> GetAll();
        Task<StudentTB> GetStudentByID(int studentId);
        Task<StudentTB?> GetStudentByEmail(string email);
        Task UpdateStudent(StudentTB studentTB);
        Task Delete(StudentTB studentTB);
    }
}
