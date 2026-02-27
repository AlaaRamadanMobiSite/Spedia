using Microsoft.EntityFrameworkCore;
using Spedia.DataBaseContext;
using Spedia.DataBaseModels;
using System.Threading.Tasks;

namespace Spedia.EndPoints.StudentEndPoints.StudentContextService
{
    public class StudentSevice : IStudentService
    {
        private readonly SpediaContext Context;
        public StudentSevice(SpediaContext Context)
        {
            this.Context = Context;
        }

        public async Task AddStudent(StudentTB studentTB)
        {
            await Context.StudentTBs.AddAsync(studentTB);
            await Context.SaveChangesAsync();
        }

        public async Task<IQueryable<StudentTB>> GetAll()
        {
            var quiry = Context.StudentTBs.AsNoTracking();
            return await Task.FromResult(quiry);
        }

        public async Task<StudentTB?> GetStudentByID(int studentId)
        {
            // IQueryable الافضل انك تستخدم هنا كمان
            return await Context.StudentTBs.Include(e=> e.Level)
                .Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
        }

        public async Task<StudentTB?> GetStudentByEmail(string email)
        {
            return await Context.StudentTBs.Where(x => x.StudentEmail == email).FirstOrDefaultAsync();
        }

        public async Task<StudentTB?> GetStudentByName(string name)
        {
            return await Context.StudentTBs.Where(x => x.StudentName == name).FirstOrDefaultAsync();
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
