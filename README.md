# VirtualMindTest

Los ejercicios se encuentran en sus carpetas correspondientes (Javascript y NET)

# Carpeta Javascript:

Cada ejercicio esta resuelto en un archivo HTML separado para poder probarlos uno por uno (incluyen el codigo javascript directamente en su body).

# Carpeta NET:

Contiene el Test Generico de .NET.

El script de sql para crear la base de datos, crear la tabla User, y llenarla con datos, esta ubicado en NET/MyRestfullApp/Scripts/DB.sql

La aplicacion web corre en el puerto 8080 de IIS Express.

En el archivo Web.config (del proyecto MyRestfullApp) y en App.config (del proyecto MyRestfullApp.Tests), en la seccion connectionStrings, hay que reemplazar los valores siguientes:

. data source (por el servidor\instancia donde se encuentra la BD)
. user id (por el correspondiente user)
. password (por el correspondiente password)
