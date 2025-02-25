# Course Management API

## Overview
This API provides a course management system where trainers can manage their courses, track payments, and generate reports. The system allows trainers to authenticate, perform CRUD operations on courses, link trainers to courses, and retrieve basic reports.

## Try the APIs
To access the project swagger without installing the project locally use this link: http://coursemanagementapi.runasp.net/swagger/index.html, and make sure that the link is running on http protocol not https.

#Quick note
by using register API will create a new trainer which should be the user to access the rest of APIs.

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
   git clone https://github.com/khaledtarek54/CourseManagementAPI.git
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
## What should be implemented next
I was going to add more features like `Docker`, `redis`, `serliog` and more but I didn't have that much time.

Thank you


