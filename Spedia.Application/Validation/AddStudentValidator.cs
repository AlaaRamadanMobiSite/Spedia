using FastEndpoints;
using FluentValidation;

namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class AddStudentValidator
    {
        public class Validator : Validator<AddStudentRequest>
        {
            public Validator()
            {
                RuleFor(e => e.StudentName).NotEmpty().WithMessage("يجب ادخال اسم الطالب");
                RuleFor(e => e.StudentEmail).NotEmpty().WithMessage("يجب ادخال ايميل الطالب")
                    .EmailAddress().WithMessage("يجب ادخال الايميل بطريقه صحيحه");
            }
        }
    }
}
