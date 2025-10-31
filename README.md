# 💳 API de Gestión de Pagos

Esta es una API de REST simple desarrollada en ASP.NET Core (.NET 8/7/6) para registrar y consultar pagos de servicios. El proyecto está completamente "dockerizado" usando Docker Compose para un fácil despliegue y desarrollo, e implementa una arquitectura limpia en capas (Controlador, Servicio, Repositorio).

---

## 🚀 Stack de Tecnología y Arquitectura

* **Framework:** ASP.NET Core Web API
* **Lenguaje:** C#
* **Arquitectura:** Arquitectura en Capas
    * **Controlador:** Maneja las peticiones y respuestas HTTP.
    * **Servicio:** Contiene toda la lógica de negocio.
    * **Repositorio:** Abstrae el acceso a los datos.
* **Base de Datos:** PostgreSQL
* **ORM:** Entity Framework Core
* **Contenerización:** Docker / Docker Compose
* **Documentación API:** Swagger / OpenAPI
* **Stack de Desarrollo (Incluido):** Kafka y Zookeeper (para futuras expansiones de arquitectura basada en eventos).



---

## 🏁 Cómo Empezar (Getting Started)

Sigue estos pasos para levantar el entorno completo en tu máquina local.

### 1. Prerrequisitos

* [Docker Desktop](https://www.docker.com/products/docker-desktop/) (o Docker Engine en Linux).
* [.NET SDK](https://dotnet.microsoft.com/en-us/download) (Requerido para ejecutar las migraciones de EF Core).

### 2. Levantar los Servicios

El `docker-compose.yml` gestionará la base de datos, Kafka, Zookeeper y la propia API.

```bash
# Este comando construirá la imagen de tu API y levantará todos los servicios
docker-compose up --build -d