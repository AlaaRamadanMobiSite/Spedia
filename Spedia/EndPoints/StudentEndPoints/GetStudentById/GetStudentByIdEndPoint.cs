using FastEndpoints;
using Spedia.Application.Student.GetStudentByID;

namespace Spedia.EndPoints.StudentEndPoints.GetStudentById
{
    public class GetStudentByIdEndPoint : Endpoint<GetStudentByIDRequest, GetStudentByIDResponse>
    {
        private readonly GetStudentByIdUseCase getStudent;
        public GetStudentByIdEndPoint(GetStudentByIdUseCase getStudent)
        {
                this.getStudent = getStudent;
        }

        public override void Configure()
        {
            Post("Student/GetById");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentByIDRequest request , CancellationToken cancellationToken)
        {
            try
            {
                var student = await getStudent.GetStudentByIDAsync(request);
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
