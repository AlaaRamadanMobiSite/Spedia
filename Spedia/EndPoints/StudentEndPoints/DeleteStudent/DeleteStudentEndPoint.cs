using FastEndpoints;

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
                await Send.OkAsync(student, cancellationToken);
            }
            catch (ArgumentException ex)
            {

                AddError(ex.Message);
                await Send.ErrorsAsync(400, cancellationToken);
            }

        }
    }
}
