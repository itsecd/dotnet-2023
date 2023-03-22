using Media.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MediaRepository>();//добавление репозитория
//builder.Services.AddTransient<MadiRepository>();//будет создаваться каждый раз
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();// можно юзатьь можно не юзать

app.UseAuthorization();// можем не использовать

app.MapControllers();

app.Run();
