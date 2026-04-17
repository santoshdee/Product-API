# Product API (ASP.NET Core + EF Core + SQL Server)

## Overview
This project is a RESTful API built using **ASP.NET Core**, **Entity Framework Core**, and **SQL Server**.

It demonstrates:
- CRUD operations
- One-to-Many relationship (Category → Products)
- DTO-based architecture
- Service layer
- Validation using Data Annotations

---

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (API testing)

---

## Project Structure
- Controllers/ -> API endpoints
- Services/    -> Business logic
- Models/      -> Database entities
- DTOs/        -> Request/Response models
- Data/        -> DbContext

## API Endpoints

### Category APIs
- GET /api/category
- GET /api/category/{id}
- POST /api/category

### Product APIs
- GET /api/products
- GET /api/products/{id}
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}

## Architecture flow
`Client(Frontend / Swagger / Postman) -> Controller -> Service -> DbContext ->SQL Server`

## Running the project
`dotnen run`
- Open Swagger: `http://localhost:<port>/swagger`
