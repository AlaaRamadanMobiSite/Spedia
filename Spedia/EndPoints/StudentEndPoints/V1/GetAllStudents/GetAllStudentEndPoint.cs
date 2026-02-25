using FastEndpoints;
using Spedia.Application.Student.GetAllStudent;
using Spedia.EndPoints.StudentEndPoints.GetAllStudents;
using System.Threading.Tasks;

namespace Spedia.EndPoints.StudentEndPoints.V1.GetAllStudents
{
    public class GetAllStudentEndPoint : Endpoint<GetAllStudentRequest, GetAllStudentResponse>
    {
        private readonly GetAllStudentsUseCase UseCase;
        public GetAllStudentEndPoint(GetAllStudentsUseCase UseCase)
        {
            this.UseCase = UseCase;
        }

        public override void Configure()
        {
            Get("Student/V1/Get/All/Student/{PageNumber}/{RowCount}");
            //AllowFormData(true);
            AllowAnonymous();
            //Description(x => x.WithTags("Grades"));
        }

        public override async Task HandleAsync(GetAllStudentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await UseCase.GetAllStudentAsync(request);

                if (response.ErrorCode != 105)
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
