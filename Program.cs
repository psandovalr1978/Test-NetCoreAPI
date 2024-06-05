using Microsoft.EntityFrameworkCore;
using Serilog;
using Test.DataContext;
using Test.MiddleWareError;
using Test.Servicios.ServicioCliente;
using Test.Servicios.ServicioCliente.Interface;

var builder = WebApplication.CreateBuilder(args);

//Configuracion del Log
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logAplicacion/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();

try
{
    // Acceso al string de conexión
    var conexion = builder.Configuration.GetConnectionString("ConexionBD");

    // Conexión de base de datos
    builder.Services.AddDbContext<ContextoBD>(op => op.UseSqlite(conexion));

    // Se agrega el middleware de manejo de errores
    builder.Services.AddScoped<ManejoErrorMiddleware>();

    // Se agregan servicios
    builder.Services.AddTransient<IServicioCliente, ServicioCliente>();

    builder.Services.AddControllers();

    // Configuración de Swagger/OpenAPI
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configuración CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    var app = builder.Build();

    // Configurar el pipeline de HTTP
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("AllowAllOrigins");

    app.UseMiddleware<ManejoErrorMiddleware>();

    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Inicia la aplicación: {0}",DateTime.Now);

    app.Run();
    
    
}
catch (Exception ex)
{
    Log.Fatal(ex, "Error fatal cuando se inicia la aplicación.");
}
finally
{
    Log.CloseAndFlush();
}

