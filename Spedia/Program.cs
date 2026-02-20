using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Spedia.Application.Student.GetStudentByID;
using Spedia.DataBaseContext;
using Spedia.DataBaseModels;
using Spedia.EndPoints.StudentEndPoints.AddStudent;
using Spedia.EndPoints.StudentEndPoints.DeleteStudent;
using Spedia.EndPoints.StudentEndPoints.GetAllStudents;
using Spedia.EndPoints.StudentEndPoints.StudentContextService;
using Spedia.EndPoints.StudentEndPoints.UpdateStudent;
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
builder.Services.AddDbContext<SpediaContext>(op => op.UseSqlServer(connection));

builder.Services.AddScoped<IStudentService, StudentSevice>();
builder.Services.AddScoped<StudentUseCase>();
builder.Services.AddScoped<GetAllStudentsUseCase>();
builder.Services.AddScoped<UpdateStudentUseCase>();
builder.Services.AddScoped<IUploadImage, UploadImage>();
builder.Services.AddScoped<DeleteStudentUseCase>();
builder.Services.AddScoped<GetStudentByIdUseCase>();


var app = builder.Build();
app.UseFastEndpoints();

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
