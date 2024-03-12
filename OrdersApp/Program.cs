using MediatR;
using OrdersApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DataStorage>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// Register MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// Swagger
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
