using DataAcces;
using DataAccess;
using DataAccess.Interfaces;
using MercaExpress.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IInventariosService, InventariosService>();
builder.Services.AddSingleton<IInvoiceService, InvoiceService>();
builder.Services.AddSingleton<ISuplierService, SuplierService>();   
builder.Services.AddControllers();

builder.Services.AddSingleton<IProductRepo, ProductRepo>();
builder.Services.AddSingleton<IInvoiceRepo, InvoiceRepo>();
builder.Services.AddSingleton<IInventariosRepo, InventariosRepo>();
builder.Services.AddSingleton<IClientRepo, ClientRepo>();
builder.Services.AddSingleton<ISuplierRepo, SuplierRepo>();
builder.Services.AddSingleton<IBaseRepo, BaseRepo>();

// Load the appsettings.json configuration
var configuration = new ConfigurationBuilder()
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
// Get the connection string from the configuration
var connectionString = configuration.GetConnectionString("MercaExpressDB");
builder.Services.AddSingleton(connectionString);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

