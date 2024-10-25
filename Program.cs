using DapperTest.Data.Extensions;
using DapperTest.Data.Utility;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<ConnectionOptions>(
    builder.Configuration.GetSection(ConnectionOptions.Position));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InterviewDapperHRTest API");

    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
