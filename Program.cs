using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShelterHelperAPI.Models;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


var builder = WebApplication.CreateBuilder(args);
var allowSpecificOrigins = "_allowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShelterContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ShelterContext")));
builder.Services.AddCors(options =>
{
	options.AddPolicy(name:allowSpecificOrigins,
		policy =>
		{
			policy.WithOrigins("https://localhost:7082", "https://localhost:7147")
			.AllowAnyHeader()
			.AllowAnyMethod();
		});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<ShelterContext>();	
}



app.UseHttpsRedirection();
app.UseCors(allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
