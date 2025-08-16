# Finaktiva - Prueba Técnica Event Logs

Este proyecto está compuesto por un frontend desarrollado en Angular 20 y
un backend desarrollado en .NET Core 9. A continuación, se detallan los pasos
para instalar y ejecutar ambos.

---

## Funcionalidades

-   Registro de eventos
    -   Permite a los usuarios registrar eventos.
-   Filtrado de eventos por fecha y por tipo de eventos
    -   Permite a los usuarios filtrar eventos por rango de fechas y tipo de evento.
-   Visualización de eventos en una tabla los resultados del registro y Filtrado
-   Si el registro del evento se realiza de API en cosumos como Postman o swagger, el evento se registra como API.
-   Al iniciar al proyecto abrirá swagger con la documentación de la API.

# Documentación

-   Internamente cada Service se realiza la documentación necesaria para cada método , con su descrión y flujo de proceso.

## Requisitos previos

Asegúrate de tener instalados los siguientes programas en tu sistema:

-   **Node.js** (versión 16 o superior) y npm (incluido con Node.js)
-   **Angular CLI** (versión 20 o superior):
    `bash
npm install -g @angular/cli
    `
-   **Visual Studio Code o el Editor de tu preferencia**: Si se va usar este editor para
    ejecutar el proyecto debes bajar las extensiones de .Net install tool, y se te guiara por un proceso para que descargues el sdk correspondiente a .net core 9

-   **Opcional (Visual Studio Community)** : Para este caso es necesario realizar instalación del .net Core 9

# Creación de Base de datos SQL Server

En la base del proyecto se encuentra el archivo **queryDbs.sql** en SQL Server y ejecutarlo
para la creación de la base de datos **Registration**.

## Instalación del proyecto

Navega hasta la carpeta del frontend FrontEventLogs/front-event-Logs
`bash
cd FrontEventLogs/front-event-logs
    `
Instala las dependencias
`bash
npm install
    `
Inicia el servidor de desarrollo
`bash
npm install
    `

## Instalación de .Net

Navega hasta la carpeta del frontend BackEventLogs/BackWebApi
`bash
cd BackEventLogs/BackWebApi
    `
Instala las dependencias
`bash
dotnet restore
    `
Configura la base de datos (si aplica):

Asegúrate de que el archivo appsettings.json tenga la configuración correcta para la conexión a tu base de datos SQL Server.

Inicia el servidor de desarrollo,

Para MAC , desde la terminal se realiza con el siguiente comando
`bash
dotnet run --launch-profile https --configuration Debug
    `
Para windows desde la terminal se realiza con el siguiente comando
`bash
dotnet run
    `
Si es desde Visual Studio Community

1. Abre el proyecto BackWebApi en Visual Studio.
2. Selecciona el perfil de lanzamiento adecuado (por ejemplo, IIS Express o Kestrel).
3. Haz clic en "Iniciar" o presiona F5 para compilar y ejecutar el proyecto.
