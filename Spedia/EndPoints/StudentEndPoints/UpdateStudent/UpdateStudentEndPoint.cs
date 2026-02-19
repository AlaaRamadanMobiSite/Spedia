using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Spedia.EndPoints.StudentEndPoints.AddStudent;

namespace Spedia.EndPoints.StudentEndPoints.UpdateStudent
{
    public class UpdateStudentEndPoint : Endpoint<UpdatStudentRequest>
    {
        private readonly UpdateStudentUseCase useCase;
        public UpdateStudentEndPoint(UpdateStudentUseCase useCase)
        {
            this.useCase = useCase;
        }

        public override void Configure()
        {
            Put("Student/Update/Student");
            AllowFormData(true);
            AllowAnonymous();
            AllowFileUploads();
            //Description(x => x.WithTags("Student"));
        }

        public override async Task HandleAsync(UpdatStudentRequest request , CancellationToken cancellationToken)
        {
            try
            {
                var response = useCase.UpdateStudentAsync(request);
                if (await response)
                    await Send.OkAsync("تم تحديث البيانات بنجاح", cancellationToken);
                else
                    await Send.NotFoundAsync(cancellationToken);
            }
            catch(ArgumentException ex)
            {
                AddError(ex.Message); 
                await Send.ErrorsAsync(400, cancellationToken);
            }
        }
    }
}
