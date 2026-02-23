using FastEndpoints;
using FluentValidation;

namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class AddStudentValidator : Validator<AddStudentRequest>
    {
        public AddStudentValidator()
        {
            //ValidationFailure

            RuleFor(e => e.StudentName)
               .NotEmpty().WithMessage("الاسم مطلوب").WithErrorCode("102")
               .Must(name => name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length >= 4)
               .WithMessage("يجب أن يكون الاسم رباعياً على الأقل").WithErrorCode("103");
            RuleFor(e => e.StudentEmail).NotEmpty().WithMessage("يجب ادخال ايميل الطالب").WithErrorCode("104")
               .EmailAddress().WithMessage("يجب ادخال الايميل بطريقه صحيحه").WithErrorCode("106");
        }
    }
}
