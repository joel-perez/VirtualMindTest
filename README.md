# VirtualMindTest

Los ejercicios se encuentran en sus carpetas correspondientes (Javascript y NET).

# Carpeta Javascript

Cada ejercicio esta resuelto en un archivo HTML separado para poder probarlos uno por uno (incluyen el codigo javascript directamente en su body).

# Carpeta NET

Contiene el Test Generico de .NET: una REST Web API en Visual Studio 2015 / .NET Framework 4.5.2.

La aplicacion web corre en el puerto 8080 de IIS Express.

## Configuracion de base de datos

El script `NET/MyRestfullApp/Scripts/DB.sql` crea la base `MyRestfullApp`, la tabla `User` (id, nombre, apellido, email, password) y la carga con datos de prueba.

En `Web.config` (proyecto MyRestfullApp) y en `App.config` (proyecto MyRestfullApp.Tests), en `connectionStrings`, reemplazar:

- data source (servidor\instancia de SQL Server)
- user id
- password

## Servicios

Cotizacion (patron Strategy):

- GET http://localhost:8080/MyRestfullApp/Cotizacion/Dolar  
  Reproduce el consumo original de `http://www.bancoprovincia.com.ar/Principal/Dolar` (GET, array JSON `[compra, venta, fecha]`). Ese sitio ya no publica el servicio; con `UsarStubBancoProvincia=true` (Web.config / App.config de tests) se intercepta el HTTP con la misma forma de respuesta.
- GET http://localhost:8080/MyRestfullApp/Cotizacion/Pesos  
  HTTP 401 Unauthorized
- GET http://localhost:8080/MyRestfullApp/Cotizacion/Real  
  HTTP 401 Unauthorized

Usuarios (ABM sobre la tabla User):

- GET http://localhost:8080/MyRestfullApp/Usuarios
- GET http://localhost:8080/MyRestfullApp/Usuarios/{id}
- POST http://localhost:8080/MyRestfullApp/Usuarios
- PUT http://localhost:8080/MyRestfullApp/Usuarios/{id}
- DELETE http://localhost:8080/MyRestfullApp/Usuarios/{id}

## Tests

Los tests de la capa de servicios interna estan en `MyRestfullApp.Tests/Services`. El de dolar recorre el mismo flujo HTTP/JSON que el servicio real, usando el stub. Ejecutarlos desde Visual Studio (Test Explorer) despues de crear la base con el script.
