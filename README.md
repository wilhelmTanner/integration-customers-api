# :star2: Agregar título (*ej: Api para la gestión de...*) :star2:
---
Este servicio es de uso transversal, creado inicialmente para el proyecto Portal deudores. Aqui se añadirán los distintos servicios de botón de pago que nos 
ofrecerán los distintos proveedores.

[[_TOC_]]

## Funcionalidades
- Crear cobro con Khipu
- Obtener y encolar en service bus respuesta de Khipu

> [!Tip]
> La descripción de los endpoints se puede encontrar en la documentación del api [Swagger](https://nginx-dev.tanner.cl/enterprise/payment-button/main/swagger/index.html).
## Equipo 

- [Susan De Mello Pinto](mailto:susan.demello@tanner.cl) (PM)
- [Máximo Henriquez](mailto:maximo.henriquez@tanner.cl) (Coordinador)
- [Felipe Serrano](mailto:felipe.serrano@tanner.cl) (Dev)
- [Cristopher Martel](mailto:cristopher.martel@tanner.cl) (Dev)
- [Paula Baez](mailto:paula.baez@tanner.cl) (Qa)
- [Maximiliano Diaz](mailto:maximiliano.diaz@tanner.cl) (Ux)

## Herramientas

- [NET 8](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/downloads/)
- [Docker](https://www.docker.com/) (opcional)
- [Mongo DB Compass](https://www.mongodb.com/products/compass)
- [Azure Service bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview)
- [Azure Application Insights](https://learn.microsoft.com/es-es/azure/azure-monitor/app/app-insights-overview)
- [Azure Key Vault](https://learn.microsoft.com/es-es/azure/key-vault/general/overview)
- [Azure Api Management](https://learn.microsoft.com/es-es/azure/api-management/)


## Documentación (*Entregar un poco mas de información sobre el proyecto, que hace?, con quien se integra?*)

Este repositorio consiste de una WebApi que expone los endpoints necesarios para la comunicación con proveedores de botón de pago, 
un endpoint `/health` para verificar que se encuentra disponible y está documentado con [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore).

## Secretos

Los credenciales de apis, servicios y cadenas de conexión para los distintos ambientes deben incluirse en el archivo `release.yaml`, configurados a nivel de proyecto y guardados en el Key Vault `kv-des-payment-button`.

| Nombre(s) | Servicio | Tipo |
|--|--|--|
| `instrumentation-key` | ai-payment-portal-dev | Application Insights |
| `user-mongodb`, `pass-mongodb` | mongodb-tanner-dev | Atlas MongoDb |
> [!Tip]
> Tener en cuenta que tanto el InstrumentationKey, las credenciales de apis, y el usuario y contraseña de la cadena de conexión a MongoDb deben ser secretos y obtenidos desde el AKV.

## Desarrollo

Para el ambiente local de desarrollo debe tener en cuenta los siguientes cambios en el archivo local `appsettings.json`:

1. Configurar los niveles de logging según ambiente.

    ```json
    "Logging": {
        "LogLevel": {
            "Default": "Debug"
        },
        "ApplicationInsights": {
            "LogLevel": {
                "Default": "Debug"
            }
        }
    }
    ```
	
2. Introducir el valor del *instrumentation-key* para el Application Insights.

    ```json
    "ApplicationInsights": {
        "InstrumentationKey": "<instrumentation-key>"
    }
    ```