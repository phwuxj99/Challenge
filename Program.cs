using Challenge.Repositories;
using Microsoft.OpenApi.Models;

string swaggerTitle = "Insurance Policies API";
 string swaggerVersion = "v1";

//var config = ConfigurationHelper.GetConfiguration();
var configuration = new ConfigurationBuilder()
            .AddCommandLine(Environment.GetCommandLineArgs())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
var swaggerEndpoint = configuration.GetSection("Swagger:Endpoint").Get<string>();
//var ip = configuration["Endpoint:ip"];
//var port = configuration["Endpoint:port"];

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IInsurancePolicyRepository, InsurancePolicyRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(swaggerVersion, new OpenApiInfo { Title = swaggerTitle, Version = swaggerVersion });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
