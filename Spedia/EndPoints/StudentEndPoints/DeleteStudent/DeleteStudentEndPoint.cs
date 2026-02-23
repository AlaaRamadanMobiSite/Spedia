using FastEndpoints;
using Spedia.Migrations;

namespace Spedia.EndPoints.StudentEndPoints.DeleteStudent
{
    public class DeleteStudentEndPoint : Endpoint<DeleteStudentRequest,DeleteStudentResponse>
    {
        private readonly DeleteStudentUseCase useCase;
        public DeleteStudentEndPoint(DeleteStudentUseCase useCase)
        {
                this.useCase = useCase;
        }

        public override void Configure()
        {
            Delete("Student/Delete/Student");
            AllowAnonymous();
            AllowFormData(true);
        }

        public override async Task HandleAsync(DeleteStudentRequest request , CancellationToken cancellationToken)
        {
            try
            {
                var student = await useCase.DeleteStudentAsync(request.Id);
                if (student.ErrorCode == 204)
                    await Send.ResponseAsync(student, 204, cancellationToken);
                else
                    await Send.ResponseAsync(student, 404, cancellationToken);

            }
            catch (ArgumentException ex)
            {

                AddError(ex.Message);
                await Send.ErrorsAsync(400, cancellationToken);
            }

        }
    }
}
