using AutoMapper;
using LibrarySchoolServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILibrarySchoolRepository, LibrarySchoolRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

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
