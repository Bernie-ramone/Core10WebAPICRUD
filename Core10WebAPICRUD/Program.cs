using Core10WebAPICRUD.EndPoints;
using Core10WebAPICRUD.Persistence;
using Core10WebAPICRUD.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MovieDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMovieService, MovieService>();

var app = builder.Build();

await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<MovieDbContext>())
{
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!")
   .Produces(200, typeof(string));

app.MapMovieEndpoints();

app.Run();
