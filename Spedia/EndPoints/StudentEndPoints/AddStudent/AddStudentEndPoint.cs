using FastEndpoints;
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
                if (response != null)
                    await Send.OkAsync(new AddStudentResponse()
                    {
                        StudentName = response.StudentName,
                        StudentEmail = response.StudentEmail,
                        LevelId = response.LevelId,
                        StudentPass = response.StudentPass,
                    }, cancellationToken);
                else
                    await Send.NotFoundAsync(cancellationToken);
            }
            catch(ArgumentException ex)
            {
                AddError(ex.Message); // بتضيف الرسالة لليستة الأخطاء
                await Send.ErrorsAsync(400, cancellationToken);
            }
        }
    }
}
