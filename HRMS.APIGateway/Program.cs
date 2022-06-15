using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var webApplicationOptions = new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args,
};
var builder = WebApplication.CreateBuilder(webApplicationOptions);

////////
///Configer Ocelot
///
var configBuilder = new ConfigurationBuilder();
// Add services to the container.
configBuilder.SetBasePath(builder.Environment.ContentRootPath)
               //add configuration.json  
               .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables();



builder.Services.AddOcelot(builder.Configuration);








builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseOcelot();
app.MapControllers();

app.Run();
