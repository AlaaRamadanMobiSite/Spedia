using FastEndpoints;
using Microsoft.AspNetCore.Http;
namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class AddStudentEndPoint : Endpoint<AddStudentRequest, AddStudentResponse>
    {
        private readonly StudentUseCase studentUseCase;
        public AddStudentEndPoint (StudentUseCase studentUseCase)
        {
            this.studentUseCase = studentUseCase;
        }

        public override void Configure()
        {
            Post("Student/Add/Student");
            AllowFormData(true);
            AllowAnonymous();
            AllowFileUploads();
            //Description(x => x.WithTags("Student"));
        }

        public override async Task HandleAsync(AddStudentRequest request  , CancellationToken cancellationToken)
        {
            try
            {
                var response =await studentUseCase.AddStudentAsync(request);
                if (response.ErrorCode == 201)
                    await Send.ResponseAsync(response,201, cancellationToken);
                else
                    await Send.ResponseAsync(response, 400, cancellationToken);
            }
            catch (ArgumentException ex)
            {
                AddError(ex.Message); // بتضيف الرسالة لليستة الأخطاء
                await Send.ErrorsAsync(400, cancellationToken);
            }
        }
    }
}
