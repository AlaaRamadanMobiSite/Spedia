using Microsoft.EntityFrameworkCore;
using Spedia.DataBaseContext;
using Spedia.DataBaseModels;
using System.Threading.Tasks;

namespace Spedia.EndPoints.StudentEndPoints.StudentContextService
{
    public class StudentContext : IStudentContext
    {
        private readonly SpediaContext Context;
        public StudentContext(SpediaContext Context)
        {
            this.Context = Context;
        }

        public async Task AddStudent(StudentTB studentTB)
        {
            await Context.StudentTBs.AddAsync(studentTB);
            await Context.SaveChangesAsync();
        }

        public async Task<List<StudentTB>> GetAll()
        {
            return await Context.StudentTBs.ToListAsync();
        }

        public async Task<StudentTB> GetStudentByID(int studentId)
        {
            return await Context.StudentTBs.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
        }

        public async Task UpdateStudent(StudentTB studentTB)
        {
             Context.Update(studentTB);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(StudentTB studentTB)
        {
             Context.StudentTBs.Remove(studentTB);
            await Context.SaveChangesAsync();
        }


    }
}
