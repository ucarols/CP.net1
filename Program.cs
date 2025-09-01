using MotoPatioApi.Data;
using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ?? Força escutar na porta 8080 (funciona dentro do container)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // <-- ponto chave!
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

var app = builder.Build();

// Ambiente de dev = Swagger ativado
if (app.Environment.IsDevelopment() || true) // <-- deixa sempre ativo
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); ? REMOVA HTTPS para não dar erro no Docker
app.UseAuthorization();
app.MapControllers();
app.Run();
