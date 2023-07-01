using AutoMapper;
using LibrarySchool.Domain;
using LibrarySchoolServer;
<<<<<<< HEAD
using LibrarySchoolServer.Dto;
=======
using Microsoft.AspNetCore.Builder;
>>>>>>> 2-dto-classes-to-records
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
<<<<<<< HEAD

// 3 issue
=======
//2 - issue
>>>>>>> 2-dto-classes-to-records
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

});
<<<<<<< HEAD
builder.Services.AddScoped<IValidator<StudentPostDto>, StudentPostDtoValidator>();
builder.Services.AddScoped<IValidator<ClassTypePostDto>, ClassTypePostDtoValidator>();
builder.Services.AddScoped<IValidator<SubjectPostDto>, SubjectPostDtoValidator>();
builder.Services.AddScoped<IValidator<MarkPostDto>, MarkPostDtoValidator>();
=======

>>>>>>> 2-dto-classes-to-records
builder.Services.AddDbContextFactory<LibrarySchoolContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(LibrarySchool));
    optionsBuilder.UseMySQL(connectionString!);
});

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
