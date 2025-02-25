# Course Management API

## Overview
This API provides a course management system where trainers can manage their courses, track payments, and generate reports. The system allows trainers to authenticate, perform CRUD operations on courses, link trainers to courses, and retrieve basic reports.

## Tech Stack
- .NET Core
- Entity Framework Core
- JWT Authentication
- SQL Server
- Swagger for API documentation

## Installation & Setup
### Prerequisites
- .NET SDK installed
- SQL Server
- Postman (optional for testing API endpoints)

### Steps to Run
1. Clone the repository:
   ```sh
   git clone <repository-url>
   cd CourseManagementAPI
   ```
2. Update `appsettings.json` with database connection details.
3. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the API:
   ```sh
   dotnet run
   ```

## API Documentation
The API documentation is available through Swagger. Once the API is running, navigate to:
```
http://localhost:<port>/swagger
```
It provides details about available endpoints, request/response formats, and authentication.

## Authentication
The API uses JWT authentication. To authenticate:
1. Register/Login to obtain a token.
2. Include the token in the `Authorization` header as:
   ```sh
   Authorization: Bearer <your-token>
   ```

## Features
- **Trainer Management**: CRUD operations on trainers.
- **Course Management**: CRUD operations on courses.
- **Course-Trainer Linking**: Assign courses to trainers.
- **Payment Tracking**: Manage trainer payments.
- **Reporting**: Basic reporting on trainer-course linkages.

## Running Unit Tests
(Coming Soon - Once unit tests are implemented)
```sh
   dotnet test
```



