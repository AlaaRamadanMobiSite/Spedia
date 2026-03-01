using Microsoft.EntityFrameworkCore;
using Spedia.DataBaseContext;
using Spedia.Domain.DataBaseModels;
using Spedia.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Infrastructure.StudentFatherServices
{
    public class StudentFatherService : IStudentFatherService
    {
        private readonly SpediaContext Context;
        public StudentFatherService(SpediaContext Context)
        {
                this.Context = Context;
        }

        public async Task AddStudentFather(StudentFather studentFather)
        {
            await Context.StudentFathers.AddAsync(studentFather);
            await Context.SaveChangesAsync();
        }

    }
}
