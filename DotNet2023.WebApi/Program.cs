using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Organization;
using DotNet2023.WebApi.Repository.Organization;
using DotNet2023.WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextWebApi>();
IConfiguration configuration = builder.Configuration;

configuration.GetSection(Config.Project).Bind(new Config());

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddScoped<IHigherEducationInstitution, HigherEducationInstitutionRepository>();


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
