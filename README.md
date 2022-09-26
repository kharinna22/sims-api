# Sims-API
API desarrollada como proyecto ASP.NET Core Web API (.NET 6) con C#, Client-First.

## Modelo Sims
- Id
- Nombre
- Apellido 
- Edad
- IsMuerto
- IsMujer 

## Métodos
- GET: todos los sims, sim por id.
- POST: agregar nuevo sim.
- PUT: editar sim por id.
- DELETE: elimina sim por id.

## Migración
Al momento de crear nuevas clases o editar las ya existentes en el cliente, estas deben ser migradas a la base de datos. Para esto utilizar en la consola de administrador de paquetes NuGet: 
- _add-migration "New migration"_  
- _update-database_
