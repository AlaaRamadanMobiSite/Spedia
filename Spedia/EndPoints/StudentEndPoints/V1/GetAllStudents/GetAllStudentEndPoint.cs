using FastEndpoints;
using Spedia.EndPoints.StudentEndPoints.GetAllStudents;
using System.Threading.Tasks;

namespace Spedia.EndPoints.StudentEndPoints.V1.GetAllStudents
{
    public class GetAllStudentEndPoint : EndpointWithoutRequest<GetAllStudentResponse>
    {
        private readonly GetAllStudentsUseCase UseCase;
        public GetAllStudentEndPoint(GetAllStudentsUseCase UseCase)
        {
            this.UseCase = UseCase;
        }

        public override void Configure()
        {
            Get("Student/V1/Get/All/Student");
            //AllowFormData(true);
            AllowAnonymous();
            //Description(x => x.WithTags("Grades"));
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            try
            {
                var response = await UseCase.GetAllStudentAsync();

                if (response.ErrorCode == 200)
                    await Send.ResponseAsync(response, 200, cancellationToken);
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
