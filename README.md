# LibraryApp

Aplicación ASP.NET Core MVC con Entity Framework Core y SQL Server, desarrollada como práctica para gestión de Autores y Libros, con reglas de negocio específicas y soporte para Docker.

---

##  Tecnologías principales
- **.NET 8 / 9 (SDK y ASP.NET Core MVC)**
- **Entity Framework Core (EF Core con SQL Server)**
- **SQL Server 2022 (local o en Docker)**
- **Bootstrap 5 (estilos de las vistas MVC)** 
- **Docker & Docker Compose**

---

## 📂 Estructura del proyecto

```text
LibraryApp/
 ├─ Domain/
 │   ├─ Entities/ (Author, Book)
 │   ├─ DTOs/ (CreateAuthorDto, AuthorDto, CreateBookDto, BookDto)
 │   ├─ Interfaces/ (IAuthorService, IBookService)
 │   ├─ Exceptions/ (AuthorNotRegisteredException, MaxBooksExceededException)
 ├─ Infrastructure/ (AppDbContext)
 ├─ Services/ (AuthorService, BookService)
 ├─ Controllers/ (AuthorsController, BooksController)
 ├─ Views/
 │   ├─ Authors/ (Create.cshtml, Index.cshtml)
 │   ├─ Books/ (Create.cshtml, Index.cshtml)
 │   └─ Shared/ (_Layout.cshtml)
 ├─ Program.cs
 ├─ appsettings.json
 ├─ Dockerfile
 └─ docker-compose.yml
```

---

## Instalacion y Ejecucion

1- **Clonar el repositorio**
```bash
[git clone https://github.com/NDANIV/E-commerce.git](https://github.com/NDANIV/LibraryApp.git)
cd LibraryApp
```
2- **Configurar cadena de conexión en appsettings.json**
```bash
 "ConnectionStrings": {
  "Default": "Server=localhost,1433;Database=LibraryDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True"
},
"App": {
  "MaxBooks": 3
}
```
3- **Aplicar migraciones**
```bash        
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4- **Ejecutar proyecto**
```bash        
dotnet run
```
 **App disponible en: http://localhost:5000**

## Características principales
**Autores**

-Crear autores con: Nombre completo, Fecha de nacimiento, Ciudad y Email.

-Validación de campos obligatorios y formato de email.

-Restricción: Email único.

-Listado de todos los autores registrados.

**Libros**

-Crear libros con: Título, Año, Género, Número de páginas y Autor asociado.

-Validaciones de datos (campos obligatorios, rangos de año y páginas).

-Reglas de negocio:

-No se pueden registrar libros sin un autor válido.

-Existe un máximo de libros permitidos configurable en appsettings.json.

-Listado de todos los libros registrados.


## Notas 
- MaxBooks(Numero de libros permitido) es configurable desde appsettings.json o por variable de entorno (App__MaxBooks).


