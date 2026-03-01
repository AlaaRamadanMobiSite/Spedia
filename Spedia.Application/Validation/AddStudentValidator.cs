using FastEndpoints;
using FluentValidation;
using Spedia.Application.StandardResponse;

namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class AddStudentValidator : Validator<AddStudentRequest>
    {
        public AddStudentValidator()
        {
            //ValidationFailure

            RuleFor(e => e.StudentName)
               .NotEmpty().
               WithMessage("الاسم مطلوب").WithErrorCode(((int)ErrorCodeResponse.StudentNameRequired).ToString())
               .Must(name => name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length >= 4)
               .WithMessage("يجب أن يكون الاسم رباعياً على الأقل").WithErrorCode(((int)ErrorCodeResponse.StudentName4Keyword).ToString());
            RuleFor(e => e.StudentEmail).NotEmpty().
                WithMessage("يجب ادخال ايميل الطالب").WithErrorCode(((int)ErrorCodeResponse.StudentEmailRequired).ToString())
               .EmailAddress()
               .WithMessage("يجب ادخال الايميل بطريقه صحيحه").WithErrorCode(((int)ErrorCodeResponse.StudentEmailCorrectly).ToString());
            RuleFor(e => e.StudentPass).NotEmpty().WithMessage("ادخل كلمه المرور")
                .WithErrorCode(((int)ErrorCodeResponse.StudentPasswordRequired).ToString());
            RuleFor(e => e.LevelId).NotEmpty().WithMessage("ادخل رقم الصف")
                .WithErrorCode(((int)ErrorCodeResponse.StudentLevelIdRequired).ToString());
        }
    }
}
