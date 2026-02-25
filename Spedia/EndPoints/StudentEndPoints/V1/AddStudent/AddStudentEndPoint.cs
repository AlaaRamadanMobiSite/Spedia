using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Spedia.EndPoints.StudentEndPoints.AddStudent;

namespace Spedia.EndPoints.StudentEndPoints.V1.AddStudent
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
            Post("Student/V1/Add/Student");
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
                if (response.ErrorCode != 101)
                    await Send.ResponseAsync(response,201, cancellationToken);
                else if(response.ErrorCode != 107)
                    await Send.ResponseAsync(response, 400, cancellationToken);
                else
                    await Send.ResponseAsync(response, 400, cancellationToken);
            }
            catch (ArgumentException ex)
            {
                AddError(ex.Message); 
                await Send.ErrorsAsync(400, cancellationToken);
            }
        }
    }
}
