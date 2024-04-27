using DataAccess.Models;
using DataAccess.Service.Interfaces;
using DataAccess.Service;
using MinimalApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFactoryService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.MapPost("/CreateUser", CreateUserAsync);

static async Task<IResult> CreateUserAsync(UserModel userModel, IUserService service)
{
    await service.CreateUserAsync(userModel);
    return Results.Created();
}

app.Run();
