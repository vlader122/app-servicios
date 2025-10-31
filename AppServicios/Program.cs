// ... (usings)

using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Gestión de Pagos",
        Version = "v1",
        Description = "API para registrar y consultar pagos de servicios."
    });

});

builder.Services.AddScoped<IPaymentRepository,PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


builder.Services.AddDbContext<ServiciosContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ServiciosConnection"));
});



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ServiciosContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Pagos v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();