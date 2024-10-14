using ATMAPIProject.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.ServiceModel;
using System.ServiceModel.Channels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read settings from settings.txt
builder.Services.AddSingleton<ServerSettings>(serviceProvider =>
{
    var settings = new ServerSettings();
    settings.Getsettings("settings.txt");
    return settings;
});

// Register the ATMAPI_Port client
builder.Services.AddScoped<ATMAPI.ATMAPI_PortClient>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<ServerSettings>();
    var binding = new BasicHttpBinding();
    var endpoint = new EndpointAddress(settings.server); // Adjust according to your settings

    var client = new ATMAPI.ATMAPI_PortClient(binding, endpoint);
    return client;
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
