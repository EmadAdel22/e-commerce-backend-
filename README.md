# E-Commerce Web API

A RESTful E-Commerce Web API built with ASP.NET Core. The project provides backend services for managing products, categories, 
 and order-related operations.

## Features

- Product Management (CRUD)
- Category Management (CRUD)
- Image Upload
- Entity Framework Core
- SQL Server Database
- RESTful API Design
- Swagger / OpenAPI Documentation

## Technologies Used

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## API Modules

- Authentication
- Products
- Categories
- Image Upload

## Getting Started

### Clone the repository



### Update Connection String

Update the SQL Server connection string inside `appsettings.json`.

### Apply Migrations

```bash
dotnet ef database update
```

### Run the Project

```bash
dotnet run
```

### Open Swagger

```
https://localhost:xxxx/swagger
```

## Project Structure

```
Controllers/
Data/
Models/
DTOs/
Services/
Migrations/
```

## Future Improvements

- Shopping Cart
- Orders Management
- Payment Integration
- Product Search & Filtering
- Pagination
- Product Reviews & Ratings

## Author

**Emad Adel**

GitHub: https://github.com/EmadAdel22
