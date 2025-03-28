using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:7082")
            .WithMethods("GET", "PUT", "PATCH", "OPTIONS")
            .AllowAnyHeader();
    });
});
builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShelterContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ShelterContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ShelterContext>();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();