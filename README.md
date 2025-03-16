# Todo Task - Backend

Este repositorio contiene el backend desarrollado en .NET Core con una arquitectura monolítica, utilizando autenticación JWT y SQL Server como base de datos.

## Clonación del repositorio

Para obtener una copia local del proyecto, ejecuta el siguiente comando:

```sh
git clone https://github.com/rika1707/Todo-Task-.git
```

## Instalación y configuración

### Requisitos previos
- .NET 8 SDK instalado.
- SQL Server instalado y configurado localmente.
- Herramienta de administración de base de datos como SQL Server Management Studio (SSMS).

### Configuración de la base de datos
Si deseas utilizar la base de datos localmente, debes realizar las migraciones para que se cree automáticamente la estructura en SQL Server.

Ejecuta los siguientes comandos en la terminal dentro del proyecto:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Esto generará y aplicará las migraciones necesarias para configurar la base de datos correctamente.

## Tecnologías utilizadas

- **.NET Core**: Framework principal para el desarrollo del backend.
- **SQL Server**: Base de datos utilizada para almacenar las tareas y usuarios.
- **Entity Framework Core**: ORM para la gestión de datos.
- **JWT (JSON Web Token)**: Implementación de autenticación segura para los usuarios.
- **CORS**: Configurado para permitir la comunicación entre el backend y el frontend.

## Endpoints

La API cuenta con los siguientes endpoints:

### Autenticación
- `POST https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/login` - Iniciar sesión y obtener un token JWT.

### Tareas
- `GET https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/task` - Obtener todas las tareas.
- `POST https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/task` - Crear una nueva tarea.
- `GET https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/task/{id}` - Obtener una tarea por ID.
- `PUT https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/task/{id}` - Actualizar una tarea por ID.
- `DELETE https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/task/{id}` - Eliminar una tarea por ID.
- `GET https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/process/{id}` - Procesar una tarea específica.

### Usuarios
- `GET https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/users` - Obtener todos los usuarios.
- `POST https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/users` - Crear un nuevo usuario.
- `GET https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/users/{id}` - Obtener un usuario por ID.
- `PUT https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/users/{id}` - Actualizar un usuario por ID.
- `DELETE https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/api/users/{id}` - Eliminar un usuario por ID.

## Autenticación con JWT

El backend utiliza JWT para proteger los endpoints. Para acceder a los endpoints protegidos, es necesario incluir el token JWT en la cabecera de la solicitud:

```sh
Authorization: Bearer {token}
```

## Ejecución del proyecto

Para ejecutar el backend localmente, usa el siguiente comando:

```sh
dotnet run
```

El servidor se iniciará y estará disponible en `https://localhost:7134/`.

## Despliegue

El backend está desplegado en **Azure**, y los endpoints están accesibles en:

```
https://todotaskback-e0gbbdd0cbfxevb4.canadacentral-01.azurewebsites.net/
```

## Contribución

Si deseas contribuir a este proyecto, puedes realizar un fork del repositorio y enviar un pull request con tus cambios.

---

Este backend forma parte del proyecto **Todo Task**, el cual incluye un frontend en Angular. Para más información sobre la parte del frontend, revisa su repositorio correspondiente.


