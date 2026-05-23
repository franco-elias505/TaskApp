# TaskApp - Gestor de Tareas con XAF

Aplicación de gestión de tareas desarrollada con **DevExpress eXpressApp Framework (XAF)**, **.NET 8** y **C# 12**.

## Descripción

TaskApp es una solución completa para gestionar tareas con dos interfaces disponibles:
- **Web**: ASP.NET Core Blazor Server
- **Desktop**: Windows Forms (WinForms)

### Características

- Autenticación y autorización integrada
- Gestión de usuarios y roles
- CRUD completo de tareas
- Base de datos relacional (SQL Server LocalDB)
- UI autogenerada por XAF
- Validaciones automáticas
- Persistencia de datos


## Requisitos Previos

Antes de ejecutar la aplicación, asegúrate de tener instalado:

1. **.NET 8 SDK**
   - Descargar desde: https://dotnet.microsoft.com/download
   - Verificar: `dotnet --version`

2. **SQL Server LocalDB**
   - Incluido en Visual Studio
   - O descargar desde: https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb

3. **Visual Studio 2022** (recomendado)
   - Community Edition: https://visualstudio.microsoft.com/es/vs/community/

---

## Instalación y Configuración

### 1. Clonar o descargar el repositorio

```bash
git clone <url-del-repositorio>
cd TaskApp
```

### 2. Restaurar dependencias NuGet

```bash
dotnet restore
```

### 3. Configurar la conexión a la base de datos

El archivo `appsettings.json` en `TaskApp.Blazor.Server` contiene las cadenas de conexión:

```json
{
  "ConnectionStrings": {
	"ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=TaskApp;Integrated Security=true;",
	"EasyTestConnectionString": "Server=(localdb)\\mssqllocaldb;Database=TaskAppEasyTest;Integrated Security=true;"
  }
}
```

**Si usas una instancia diferente de SQL Server**, actualiza `ConnectionString` con tu servidor.

### 4. Construir la solución

```bash
dotnet build
```

---

##  Ejecución de la Aplicación

### Opción 1: Ejecutar versión Web (Blazor Server)

#### Desde Visual Studio
1. Abre `TaskApp.sln` en Visual Studio
2. Establece `TaskApp.Blazor.Server` como proyecto de inicio
3. Presiona `F5` o haz clic en **Iniciar depuración**

#### Desde terminal (PowerShell)

```powershell
cd TaskApp.Blazor.Server
dotnet run
```

**La aplicación se abrirá en**: 
- `https://localhost:5001` (HTTPS)
- `http://localhost:5000` (HTTP)

---

### Opción 2: Ejecutar versión Desktop (Windows Forms)

#### Desde Visual Studio
1. Abre `TaskApp.sln` en Visual Studio
2. Establece `TaskApp.Win` como proyecto de inicio
3. Presiona `F5` o haz clic en **Iniciar depuración**

#### Desde terminal (PowerShell)

```powershell
cd TaskApp.Win
dotnet run
```

---

##  Credenciales de Acceso

Por defecto, la aplicación cuenta con un usuario administrativo:

| Campo | Valor |
|-------|-------|
| **Usuario** | `admin` |
| **Contraseña** | `admin123` |
| **Rol** | Admin |

** Nota**: Cambia estas credenciales en producción. La configuración se encuentra en:
- `TaskApp.Module\DatabaseUpdate\Updater.cs`
- `TaskApp.Module\Services\SecurityInitializationService.cs`

---

##  Estructura del Proyecto

```
TaskApp/
├── TaskApp.Module/                 # Módulo compartido (modelos, migraciones, controladores)
│   ├── BusinessObjects/            # Entidades de negocio (Tarea, ApplicationUser, etc.)
│   ├── DatabaseUpdate/             # Updater y seeding de datos
│   ├── Migrations/                 # Migraciones de EF Core
│   └── Controllers/                # Controladores XAF
│
├── TaskApp.Blazor.Server/          # Aplicación Web (Blazor Server)
│   ├── Startup.cs                  # Configuración de servicios
│   ├── BlazorApplication.cs        # Configuración de XAF Blazor
│   ├── appsettings.json            # Configuración y connection strings
│   └── Program.cs                  # Punto de entrada
│
├── TaskApp.Win/                    # Aplicación Desktop (Windows Forms)
│   ├── Startup.cs                  # Configuración de aplicación WinForms
│   └── Program.cs                  # Punto de entrada
│
└── README.md                       # Este archivo
```

---

## Configuración Avanzada

### Cambiar la base de datos

Si deseas usar SQL Server en lugar de LocalDB, actualiza en `appsettings.json`:

```json
"ConnectionString": "Server=TU_SERVIDOR;Database=TaskApp;Integrated Security=true;"
```

### Modo de actualización de base de datos

En `TaskApp.Blazor.Server\BlazorApplication.cs`:

```csharp
#if DEBUG
	DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;  // Auto-actualizar en DEBUG
#endif
```

---

##  Solución de Problemas

### Error: "Unable to find package source"

```bash
dotnet nuget locals all --clear
dotnet restore
```

### Error: "RuntimeException: .NET 8.0 not found"

Instala el runtime de .NET 8:
```bash
dotnet --list-runtimes
# Si no aparece net8.0, descargar desde https://dotnet.microsoft.com/download
```

### Error: "DatabaseVersionMismatchException"

La aplicación intentará actualizar la BD automáticamente en DEBUG. Si persiste:

```bash
# Eliminar y recrear la base de datos
dotnet ef database drop
dotnet ef database update
```

### Las tareas no persisten después de reiniciar

Asegúrate de que estés usando **LocalDB** (no In-Memory Database):

Verificar en `TaskApp.Blazor.Server\Startup.cs`:
```csharp
options.UseConnectionString(connectionString);  //  Correcto
// No debe haber:
// options.UseInMemoryDatabase("TaskAppDb");    //  No persistente
```



##Documentación Adicional

- **DevExpress XAF**: https://docs.devexpress.com/eXpressAppFramework/
- **Entity Framework Core**: https://learn.microsoft.com/es-es/ef/core/
- **ASP.NET Core Blazor**: https://learn.microsoft.com/es-es/aspnet/core/blazor/
- **SQL Server LocalDB**: https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb





**Última actualización**: Enero 2025  
**Versión**: 2.0 (Fase 2 - XAF)  
**Estado**: ✅ Producción
