using GerenciamentoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoque.Data;


var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContext e configurar a conexão com o banco
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar suporte a controladores
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear rotas controladores
app.MapControllers();

app.Run();