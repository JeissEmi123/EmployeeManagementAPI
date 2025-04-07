🛠️ ¿Cómo creo la base de datos?
Tienes dos opciones, según prefieras hacerlo a mano o de forma automática con EF Core:

✅ Opción A: Manualmente desde SQL Server
sql
Copiar
Editar
CREATE DATABASE EmployeesDb;
GO

USE EmployeesDb;
GO

CREATE TABLE [dbo].[Employees] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Position] NVARCHAR(100) NOT NULL,
    [Department] NVARCHAR(100) NOT NULL,
    [Salary] DECIMAL(18, 2) NOT NULL,
    [HiringDate] DATETIME NOT NULL,
    [IsActive] BIT NOT NULL
);
⚙️ Opción B: Automáticamente con EF Core
Restaura los paquetes:

bash
Copiar
Editar
dotnet restore
Aplica la migración inicial:

bash
Copiar
Editar
dotnet ef migrations add InitialCreate
dotnet ef database update
Ejecuta la API:

bash
Copiar
Editar
dotnet run
La API estará disponible en:
🌐 https://localhost:5001/swagger

🧪 ¿Cómo ejecuto las pruebas?
bash
Copiar
Editar
dotnet test
Esto correrá las pruebas unitarias que aseguran el correcto funcionamiento de la lógica de negocio del API. Ideal para mantener la calidad 💪

📡 Endpoints disponibles
Aquí tienes un resumen de lo que puedes hacer desde el EmployeesController:

Método	Ruta	Descripción
GET	/api/employees	Obtiene todos los empleados activos. Si no hay, devuelve 204.
GET	/api/employees/{id}	Consulta un empleado por su id. Devuelve 404 si no existe.
POST	/api/employees	Crea un nuevo empleado. Valida que todo esté correcto.
PUT	/api/employees/{id}	Actualiza un empleado existente. Valida existencia y datos.
DELETE	/api/employees/{id}	Desactiva lógicamente al empleado (no se elimina).
⚙️ Automatización (CI/CD)
Puedes integrar esta API con GitHub Actions o Azure DevOps para automatizar tus builds y pruebas. Aquí tienes un ejemplo básico para GitHub Actions:

yaml
Copiar
Editar
# .github/workflows/dotnet.yml
name: .NET Build and Test

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: windows-latest

    steps:
      - name: Checkout
        uses: actions/checkout@v3

      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '7.0.x'

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore

      - name: Test
        run: dotnet test --no-build --verbosity normal
🧱 Estructura del proyecto
Arquitectura por capas (Controller, Service, Repository)

Buenas prácticas con DTOs, validaciones y excepciones controladas

Entity Framework Core con migraciones

Pruebas unitarias con Xunit/NUnit

Documentación automática con Swagger

¿Tienes dudas, sugerencias o mejoras? ¡No dudes en contribuir o abrir un issue!
Gracias por pasar por aquí 🙌

