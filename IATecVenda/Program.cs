
using IATecVenda.Services;
using VendasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVendaService, VendaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    
    app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json", "IATecVenda v1");c.RoutePrefix = string.Empty;});
}

app.MapControllers();
app.Run();