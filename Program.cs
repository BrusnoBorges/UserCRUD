using System.ComponentModel.Design;
using User.Controller;
using User.Data;
using User.Interface;
using User.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserContext>();

builder.Services.AddHttpClient<IBrasilApiService, BrasilApiService>(client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/api/cep/v1/");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.addUserController();
app.addEnderecoController();

app.UseHttpsRedirection();

app.Run();

