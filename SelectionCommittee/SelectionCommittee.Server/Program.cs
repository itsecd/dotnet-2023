using SelectionCommittee.Server.Repository;
using SocialNetwork.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<SelectionCommitteeContext>(optionsBuilder
    => optionsBuilder.UseMySQL(builder.Configuration.GetConnectionString(nameof(SelectionCommittee))));

builder.Services.AddScoped<ISelectionCommitteeRepository, SelectionCommitteeRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
