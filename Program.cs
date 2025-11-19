using EcoApi.Controller.DB;
using EcoApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Porta obrigatória para ambiente Render
// Connection string do Render
var connectionString =
    builder.Configuration.GetConnectionString("ConexaoPadrao")
    ?? Environment.GetEnvironmentVariable("DATABASE_URL");

// Serviços da API
builder.Services.AddControllers(); // API, não MVC
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serviços da aplicação
builder.Services.AddScoped<IProductService, ProductService>();

// Banco PostgreSQL
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Somente em desenvolvimento: Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// NÃO usar HTTPS na Render
// app.UseHttpsRedirection();  ❌ Removido

// Mapear controllers
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/");
// Endpoint simples pra teste
app.MapGet("/", () => "API funcionando na Render!");

app.Run();
