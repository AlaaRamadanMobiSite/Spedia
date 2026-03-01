using Spedia.Application.StandardResponse;
using Spedia.Domain.DataBaseModels;
using Spedia.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.StudentFatherUseCases.AddStudentFather
{
    public class AddStudentFatherUseCase
    {
        private readonly IStudentFatherService Father;
        public AddStudentFatherUseCase(IStudentFatherService Father)
        {
                this.Father = Father;
        }

        public async Task<AddFatherResponse> AddFatherAsync(AddFatherRequest request)
        {
            var studentFather = new StudentFather
                (request.StudentFatherName,
                request.StudentFatherEmail,
                request.StudentFatherPassword,
                request.StudentFatherPhone,
                request.StudentId);

            await Father.AddStudentFather(studentFather);
            return new AddFatherResponse
            {
                ErrorCode = (int)ErrorCodeResponse.Success,
                Message = "تم الاضافة",
                IsSuccess = true,
                Data = new AddFatherDto
                {
                    StudentFatherName = studentFather.StudentFatherName,
                    StudentFatherEmail = studentFather.StudentFatherEmail,
                    StudentFatherPassword = studentFather.StudentFatherPassword,
                    StudentFatherPhone = studentFather.StudentFatherPhone,
                    StudentId = studentFather.StudentId,
                    
                }
            };


        }
    }
}
