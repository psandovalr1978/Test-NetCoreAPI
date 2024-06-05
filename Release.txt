Release Note - Proyecto .NET Core 8
Versión 1.0.0 - Junio 2024
Este proyecto de .NET Core 8 proporciona una estructura básica para una aplicación Web API que permite almacenar y gestionar datos en una base de datos SQLite. La implementación incluye la configuración esencial del entorno, la conexión a la base de datos, el manejo de errores y la integración de servicios para el manejo de clientes. Además, se ha incorporado Serilog como sistema de logging para facilitar la monitorización y depuración de la aplicación. La configuración de CORS asegura que la API pueda ser accedida desde cualquier origen, mientras que Swagger proporciona documentación automática para los endpoints disponibles.

Nuevas Características
Implementación de Middleware para Manejo de Errores:
ManejoErrorMiddleWare.cs se encarga de capturar y manejar errores globalmente, proporcionando respuestas JSON con detalles del error y registrando la información mediante Serilog.
Servicios CRUD para Cliente:
ServicioCliente.cs incluye métodos para crear, leer y actualizar registros de clientes en la base de datos.
Configuración de Logging con Serilog:
Serilog está configurado en Program.cs para registrar información de la aplicación, incluyendo errores fatales, en la consola y en archivos de log diarios.
Mejoras
Documentación de API con Swagger:
Swagger está integrado y configurado para generar documentación automática de los endpoints de la API.
Configuración de CORS:
Política de CORS "AllowAllOrigins" configurada en Program.cs para permitir solicitudes desde cualquier origen.
Correcciones de Errores
No se han registrado correcciones de errores en esta versión inicial.
Problemas Conocidos
Ningún problema conocido en esta versión.
Instrucciones de Actualización
Para actualizar a la nueva versión:

Actualizar Dependencias:
Asegúrate de tener actualizadas las dependencias de NuGet en tu proyecto.
Actualizar Configuraciones:
Revisa y actualiza las configuraciones de conexión a la base de datos y los archivos de configuración como appsettings.json.
Migraciones de Base de Datos:
Aplica las migraciones de la base de datos utilizando Entity Framework Core.