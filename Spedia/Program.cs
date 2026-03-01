using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Spedia.Application.StandardResponse;
using Spedia.Application.Student.GetStudentByID;
using Spedia.Application.StudentFatherUseCases.AddStudentFather;
using Spedia.DataBaseContext;
using Spedia.DataBaseModels;
using Spedia.Domain.IServices;
using Spedia.EndPoints.StudentEndPoints.AddStudent;
using Spedia.EndPoints.StudentEndPoints.DeleteStudent;
using Spedia.EndPoints.StudentEndPoints.GetAllStudents;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using Spedia.EndPoints.StudentEndPoints.UpdateStudent;
using Spedia.Infrastructure.StudentFatherServices;
using Spedia.UploadFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFastEndpoints();
//builder.Services.AddSwaggerGen();
builder.Services.SwaggerDocument();

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SpediaContext>(op => op.UseSqlServer
(connection , b=> b.MigrationsAssembly("Spedia.Infrastructure")));

builder.Services.AddScoped<IStudentService, StudentSevice>();
builder.Services.AddScoped<StudentUseCase>();
builder.Services.AddScoped<GetAllStudentsUseCase>();
builder.Services.AddScoped<UpdateStudentUseCase>();
builder.Services.AddScoped<IUploadImage, UploadImage>();
builder.Services.AddScoped<DeleteStudentUseCase>();
builder.Services.AddScoped<GetStudentByIdUseCase>();
builder.Services.AddScoped<IStudentFatherService, StudentFatherService>();
builder.Services.AddScoped<AddStudentFatherUseCase>();


var app = builder.Build();
app.UseFastEndpoints(config =>
{
    config.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
    {
        ctx.Response.StatusCode = 400;
        return new APIResponse<object>
        {
            ErrorCode = int.TryParse(failures.First().ErrorCode, out int code) ? code : 400,
            //ErrorCode = int.Parse(failures.First().ErrorCode),
            Message = failures.First().ErrorMessage,
            IsSuccess = false,
            Data = null
        };
    };
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
