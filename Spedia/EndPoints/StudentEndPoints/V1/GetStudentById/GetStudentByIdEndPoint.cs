using FastEndpoints;
using Spedia.Application.Student.GetStudentByID;

namespace Spedia.EndPoints.StudentEndPoints.V1.GetStudentById
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
            Get("Student/V1/GetById/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentByIDRequest request , CancellationToken cancellationToken)
        {
            try
            {
                var student = await getStudent.GetStudentByIDAsync(request);
                if (student.ErrorCode != 105)
                    await Send.ResponseAsync(student, 200, cancellationToken);
                else
                    await Send.ResponseAsync(student, 400, cancellationToken);
            }
            catch (ArgumentException ex)
            {
                AddError(ex.Message);
                await Send.ErrorsAsync(400, cancellationToken);
            }
        }

    }
}
