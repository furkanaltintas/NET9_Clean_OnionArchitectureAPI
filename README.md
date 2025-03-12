# .NET9 Clean Onion Architecture API

## Description

This project is a demonstration of how to implement Clean Architecture and Onion Architecture principles in a .NET 9 API application. The application follows best practices and patterns for building maintainable, scalable, and testable web APIs.

## Features

- **Clean Architecture**: The project is structured using the Clean Architecture pattern, ensuring separation of concerns and maintainability.
- **Onion Architecture**: The application follows Onion Architecture to create a layered design that promotes loosely coupled components.
- **.NET 9**: Built with the latest .NET version to ensure optimal performance and security.
- **Dependency Injection**: The project uses DI to manage dependencies and improve testability.

## Technologies Used

- **ASP.NET Core**: Framework used to build the web API.
- **Entity Framework Core**: ORM for database operations.
- **FluentValidation**: Library for input validation.
- **MediatR**: A library for implementing the mediator pattern.
- **AutoMapper**: Used for object-to-object mapping.
- **SQL Server**: Database used for persistence.

## Project Structure

The project follows the Onion Architecture, which divides the application into the following layers:

1. **Domain Layer**:
   - Contains core business entities and domain logic.
   - Independent of other layers, ensuring reusability and maintainability.

2. **Application Layer**:
   - Contains use cases and application logic.
   - Interfaces with the domain layer via interfaces and services to execute business logic.

3. **Infrastructure Layer**:
   - Implements interfaces defined in the application layer.
   - Contains code for external dependencies such as email services, logging, file storage, etc.

4. **Persistence Layer**:
   - Manages the database context and ORM configuration.
   - Responsible for data access and communication with the database.
   - Typically implements repositories for CRUD operations.

5. **API Layer**:
   - Contains controllers and API-related logic.
   - Exposes the application to external clients through HTTP endpoints.
