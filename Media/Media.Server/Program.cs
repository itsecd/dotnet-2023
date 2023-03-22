using Media.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MediaRepository>();//���������� �����������
//builder.Services.AddTransient<MadiRepository>();//����� ����������� ������ ���
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();// ����� ������ ����� �� �����

app.UseAuthorization();// ����� �� ������������

app.MapControllers();

app.Run();
