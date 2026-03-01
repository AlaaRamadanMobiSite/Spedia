using FastEndpoints;
using FluentValidation;
using Spedia.Application.StandardResponse;
using Spedia.Application.StudentFatherUseCases.AddStudentFather;
using Spedia.EndPoints.StudentEndPoints.AddStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.Validation
{
    public class AddStudentFatherValidator : Validator<AddFatherRequest>
    {
        public AddStudentFatherValidator()
        {
            RuleFor(e => e.StudentFatherName)
           .NotEmpty().
           WithMessage("الاسم مطلوب").WithErrorCode(((int)FatherErrorCodeResponse.StudentFatherNameRequired).ToString());
            RuleFor(e => e.StudentFatherEmail)
           .NotEmpty().
           WithMessage("الايميل مطلوب").WithErrorCode(((int)FatherErrorCodeResponse.StudentFatherEmailRequired).ToString());
            RuleFor(e => e.StudentFatherPassword)
           .NotEmpty().
           WithMessage("كلمه السر مطلوب").WithErrorCode(((int)FatherErrorCodeResponse.StudentFatherPasswordRequired).ToString());
            RuleFor(e => e.StudentFatherPhone)
           .NotEmpty().
           WithMessage("رقم التليفون مطلوب").WithErrorCode(((int)FatherErrorCodeResponse.StudentFatherPhoneRequired).ToString());
            RuleFor(e => e.StudentId)
           .NotEmpty().
           WithMessage("رقم الطالب مطلوب").WithErrorCode(((int)FatherErrorCodeResponse.StudentIdRequired).ToString());
        }
    }
}
