using OrganizationServer;

var builder = WebApplication.CreateBuilder(args);  //класс WebApplication, у него есть
//статический метод "CreateBuilder". Можно считать, что он создает Builder. Он предназначен для конфигурирования
//изменения...

// Add services to the container.

builder.Services.AddSingleton<OrganizationRepository>();  //этот объект будет один на весь репозиторий

// builder.Services.AddTransient<OrganizationRepository>();  //объект  каждый раз создается заново при каждом AddTransient

builder.Services.AddControllers(); // builder.Services - основополагающее свойство. Его тип - некоторая коллекция.
//Чтобы понять, что это такое, нужно понять, что такое Dependency Injection. Есть контейнер Dependency Inversion
// можно представлять, что это массив ...
// Этот контейнер говорит о том, что мы регистрируем объекты, но мы говорим DI контейнеру: "разрули зависимости сам".

// DependencyInjection - "магия", почитать больше про DI и DC, поскольку вам нифига не понятно.

//Все добавления классов - через Services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();  //
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();  //добавляем сваггер страницу



var app = builder.Build();  //после этого билдим

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();  //не обязательно

app.MapControllers();   //маппим мап контроллеры на маршруты

app.Run();
