using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.Organization;
using DotNet2023.WebApi.Interfaces.Person;
using DotNet2023.WebApi.Interfaces.Queries;
using DotNet2023.WebApi.Repository.InstituteDocumentation;
using DotNet2023.WebApi.Repository.InstitutionStructure;
using DotNet2023.WebApi.Repository.Organization;
using DotNet2023.WebApi.Repository.Person;
using DotNet2023.WebApi.Repository.Queries;
using DotNet2023.WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextWebApi>();
IConfiguration configuration = builder.Configuration;

configuration.GetSection(Config.Project).Bind(new Config());

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddScoped<IHigherEducationInstitution, HigherEducationInstitutionRepository>()
    .AddScoped<IInstituteSpeciality, InstituteSpecialityRepository>()
    .AddScoped<ISpeciality, SpecialityRepository>()
    .AddScoped<IDepartment, DepartmentRepository>()
    .AddScoped<IFaculty, FacultyRepository>()
    .AddScoped<IGroupOfStudents, GroupOfStudentsRepository>()
    .AddScoped<IEducationWorker, EducationWorkerRepository>()
    .AddScoped<IStudent, StudentRepository>()
    .AddScoped<IQueries, QueriesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();



app.Run();
