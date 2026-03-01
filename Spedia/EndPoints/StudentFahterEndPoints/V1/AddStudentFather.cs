using FastEndpoints;
using Spedia.Application.StudentFatherUseCases.AddStudentFather;
using System.Threading;

namespace Spedia.EndPoints.StudentFahterEndPoints.V1
{
    public class AddStudentFather : Endpoint<AddFatherRequest, AddFatherResponse>
    {
        private readonly AddStudentFatherUseCase FatheruseCase;
        public AddStudentFather(AddStudentFatherUseCase FatheruseCase)
        {
                this.FatheruseCase = FatheruseCase;
        }

        public override void Configure()
        {
            Post("StudentFather/V1/Add/Father");
            AllowFormData(true);
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddFatherRequest request , CancellationToken ct)
        {
            try
            {
                var studentFather = await FatheruseCase.AddFatherAsync(request);
                await Send.ResponseAsync(studentFather,201, ct);
            }
            catch (ArgumentException ex)
            {

                AddError(ex.Message);
                await Send.ErrorsAsync(400, ct);
            }
        }
    }
}
