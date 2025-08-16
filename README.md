# Finaktiva - Prueba Técnica Event Logs

Este proyecto está compuesto por un frontend desarrollado en Angular 20 y un backend desarrollado en .NET Core 9. A continuación, se detallan los pasos para instalar y ejecutar ambos componentes.

---

## Funcionalidades

-   Registro de eventos: Permite a los usuarios registrar eventos.
-   Filtrado de eventos por fecha y tipo: Permite filtrar eventos por rango de fechas y tipo de evento.
-   Visualización de eventos: Muestra los resultados del registro y filtrado en una tabla.
-   Registro de eventos vía API: Si el evento se registra mediante API (por ejemplo, usando Postman o Swagger), se identifica como evento de tipo API.
-   Documentación automática: Al iniciar el proyecto, se abre Swagger con la documentación de la API.

## Documentación Interna

Cada servicio incluye documentación detallada para cada método, con su descripción y flujo de proceso.

---

## Requisitos Previos

Asegúrate de tener instalados los siguientes programas en tu sistema:

-   **Node.js** (versión 19 o superior) y npm (incluido con Node.js)
-   **Angular CLI** (versión 20 o superior):

    ```bash
    npm install -g @angular/cli
    ```

-   **Visual Studio Code** o el editor de tu preferencia. Si usas VS Code, instala la extensión ".NET Install Tool" y sigue el proceso guiado para descargar el SDK correspondiente a .NET Core 9.
-   **Opcional: Visual Studio Community**. Para este caso, es necesario instalar .NET Core 9.

---

## Creación de Base de Datos SQL Server

En la raíz del proyecto se encuentra el archivo **queryDbs.sql**. Ejecútalo en SQL Server para crear la base de datos **Registration**.

---

## Instalación del Frontend

1. Navega hasta la carpeta del frontend:

    ```bash
    cd FrontEventLogs/front-event-logs
    ```

2. Instala las dependencias:

    ```bash
    npm install
    ```

3. Inicia el servidor de desarrollo:

    ```bash
    ng serve
    ```

---

## Instalación del Backend (.NET Core)

1. Navega hasta la carpeta del backend:

    ```bash
    cd BackEventLogs/BackWebApi
    ```

2. Restaura las dependencias:

    ```bash
    dotnet restore
    ```

3. Configura la base de datos:

    Asegúrate de que el archivo `appsettings.json` tenga la configuración correcta para la conexión a tu base de datos SQL Server.

4. Inicia el servidor de desarrollo:

    - En macOS para ejecutar https y poder realizar debug:

        ```bash
        dotnet run --launch-profile https --configuration Debug
        ```

    - En Windows:

        ```bash
        dotnet run
        ```

    - Desde Visual Studio Community:

        1. Abre el proyecto `BackWebApi` en Visual Studio.
        2. Selecciona el perfil de lanzamiento adecuado (por ejemplo, IIS Express o Kestrel).
        3. Haz clic en "Iniciar" o presiona F5 para compilar y ejecutar el proyecto.

---

## Paquetes Backend (.NET Core)

Al instalar el backend, se agregarán automáticamente los siguientes paquetes principales:

-   **Entity Framework Core**: ORM utilizado para la gestión de la base de datos SQL Server.
-   **Swagger**: Herramienta para la documentación automática y pruebas de la API.

Estos paquetes se instalan y configuran mediante el archivo de proyecto y el proceso de restauración (`dotnet restore`). No es necesario instalarlos manualmente.
