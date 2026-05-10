# Course Management API

> A **.NET Core** REST API for managing courses, trainers, and payments — designed with **Clean Architecture** layering, **EF Core** persistence, **JWT** auth, and **Swagger** documentation.

## What it does

Trainers register, authenticate, and manage their courses (CRUD), link themselves to courses, track payments, and pull basic reports.

## Try it without installing

A live deployment is available — visit the Swagger UI here:
**http://coursemanagementapi.runasp.net/swagger/index.html** (HTTP only, not HTTPS)

Register a trainer first; that account is the entry point for the rest of the API.

## Features

- 🔐 JWT-based authentication (register, login, refresh)
- 📚 Course CRUD with trainer ownership
- 🔗 Trainer ↔ course linking
- 💳 Payment tracking
- 📊 Basic reporting endpoints
- 📖 Swagger / OpenAPI documentation

## Architecture

Clean Architecture in four layers:

```
src/
├── Domain/             # Entities, value objects, domain interfaces
├── Application/        # Use cases, DTOs, validators (FluentValidation)
├── Infrastructure/     # EF Core repositories, JWT, external services
└── API/                # Controllers, middleware, Swagger config
```

The API layer depends on Application; Application defines interfaces that Infrastructure implements; Domain depends on nothing.

## Tech stack

- .NET Core 7+
- Entity Framework Core
- SQL Server
- JWT (Microsoft.AspNetCore.Authentication.JwtBearer)
- Swagger / Swashbuckle

## Quick start (local)

```bash
git clone https://github.com/khaledtarek54/CourseManagementAPI.git
cd CourseManagementAPI

# 1. Update connection string in src/API/appsettings.json
# 2. Apply migrations
dotnet ef database update --project src/Infrastructure --startup-project src/API

# 3. Run
dotnet run --project src/API
```

Browse Swagger at `http://localhost:<port>/swagger`.

## License

MIT

---

Built by [Khaled Tarek](https://github.com/khaledtarek54) · [LinkedIn](https://www.linkedin.com/in/khaled-tarek-eng)
