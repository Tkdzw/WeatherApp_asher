# 🌦 WeatherApp – Clean Architecture Weather System

A scalable Weather Management System built using:

* **Backend:** C# (.NET 8 Web API)
* **Architecture:** Clean Architecture
* **Database:** MySQL
* **ORM:** Entity Framework Core
* **External API:** OpenWeatherMap
* **Authentication:** JWT Bearer
* **Frontend (Planned):** Angular

---

# 📌 Project Overview

WeatherApp allows users to:

* Register & authenticate
* Save locations
* Manage preferences
* Mark favorite locations
* Sync weather data from OpenWeatherMap
* Retrieve weather history

The system is built using **Clean Architecture principles** to ensure:

* Separation of concerns
* Testability
* Scalability
* Maintainability
* Easy integration with Angular frontend

---

# 🏗 Architecture Overview

The solution follows **Clean Architecture**:

```
WeatherApp
│
├── WeatherApp.API          → Presentation Layer
├── WeatherApp.Application  → Business Logic Layer
├── WeatherApp.Domain       → Core Entities & Models
├── WeatherApp.Infrastructure → Data Access & External Services
```

---

# 📦 Project Breakdown

---

## 1️⃣ WeatherApp.Domain (Core Layer)

Contains:

* Entities
* Core business models
* No dependencies on other projects

### Entities:

* `User`
* `Location`
* `Preference`
* `WeatherRecord`
* `FavoriteLocation`

This layer contains only pure domain logic.

---

## 2️⃣ WeatherApp.Application (Business Logic Layer)

Contains:

* Interfaces
* DTOs
* Services (Business logic)
* Contracts for external services

### Folders:

```
Interfaces/
Services/
DTOs/
```

### Responsibilities:

* Defines `IUserService`
* Defines `IWeatherService`
* Defines `ILocationService`
* Defines `IWeatherApiClient`
* Defines `IJwtTokenGenerator`
* Handles validation & orchestration logic

⚠️ This layer does NOT depend on Infrastructure implementation.

---

## 3️⃣ WeatherApp.Infrastructure (Implementation Layer)

Contains:

* EF Core DbContext
* Fluent configurations
* Repository implementations
* JWT implementation
* OpenWeatherMap API integration
* Dependency injection registrations

### Folders:

```
Persistence/
Configurations/
External/
Security/
```

### Responsibilities:

* Implements `IWeatherApiClient`
* Implements `IJwtTokenGenerator`
* Configures MySQL connection
* Configures Entity relationships
* Handles external API communication

---

## 4️⃣ WeatherApp.API (Presentation Layer)

Contains:

* Controllers
* Swagger configuration
* Authentication setup
* Dependency injection setup
* Middleware configuration

### Controllers:

* `AuthController`
* `UsersController`
* `LocationsController`
* `WeatherController`

This is the entry point of the system.

---

# 🔐 Authentication

Authentication uses:

* JWT Bearer tokens
* Role-based authorization (Planned Expansion)

### Flow:

1. User registers
2. User logs in
3. JWT token is generated
4. Token is used in:

   ```
   Authorization: Bearer {token}
   ```

---

# 🌍 External Integration – OpenWeatherMap

Weather data is retrieved from:

```
https://api.openweathermap.org/data/2.5/weather
```

The `OpenWeatherApiClient`:

* Calls the API
* Deserializes the response
* Maps response to internal DTO
* Returns structured weather data

---

# 🛠 Setup Instructions

---

## ✅ 1. Clone Repository

```bash
git clone https://github.com/your-repo/weatherapp.git
cd weatherapp
```

---

## ✅ 2. Configure MySQL

Create database:

```sql
CREATE DATABASE weatherapp;
```

---

## ✅ 3. Configure appsettings.json

In `WeatherApp.API`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=weatherapp;user=root;password=yourpassword"
},
"Jwt": {
  "Key": "YourSuperSecretKeyHere",
  "Issuer": "WeatherApp",
  "Audience": "WeatherAppUsers"
},
"OpenWeather": {
  "ApiKey": "YOUR_OPENWEATHER_API_KEY",
  "BaseUrl": "https://api.openweathermap.org/data/2.5/"
}
```

---

## ✅ 4. Run Migrations

From API project directory:

```bash
dotnet ef migrations add InitialCreate -p ../WeatherApp.Infrastructure -s .
dotnet ef database update -p ../WeatherApp.Infrastructure -s .
```

---

## ✅ 5. Run Application

```bash
dotnet run
```

Access Swagger:

```
https://localhost:7142/swagger
```

---

# 🔄 Application Flow

1. User registers
2. User logs in
3. JWT token issued
4. User creates location
5. User triggers weather sync
6. System calls OpenWeather API
7. Weather data stored in DB
8. Weather returned to user

---

# 📊 Database Relationships

* User → has many Locations
* User → has one Preference
* User → has many FavoriteLocations
* Location → has many WeatherRecords

---

# 🚀 Future Improvements & Integrations

---

## 🔹 1. Global Error Handling Middleware

* Centralized exception handling
* Structured API responses
* Logging integration (Serilog planned)

---

## 🔹 2. Angular Frontend Integration

Planned frontend stack:

* Angular
* Angular HTTP Interceptors
* Route Guards
* Role-based UI control

Integration Plan:

* Secure API calls with JWT
* Map backend DTOs to Angular models
* Central API service layer

---

## 🔹 3. Rate Limiting

Planned:

* ASP.NET Core rate limiting middleware
* Protect external API calls
* Limit per-user weather sync

---

## 🔹 4. AutoMapper Integration

Planned:

* Map:

  * OpenWeather API response → Internal DTO
  * DTO → Domain Entity
  * Domain → Response DTO

Benefits:

* Cleaner services
* Reduced manual mapping
* Better separation of concerns

---

## 🔹 5. Role-Based Authorization

Future roles:

* Admin
* Standard User

Implementation plan:

```csharp
[Authorize(Roles = "Admin")]
```

---

## 🔹 6. Caching Layer

Planned:

* Redis caching
* Cache weather responses
* Reduce API calls

---

## 🔹 7. Logging & Monitoring

Planned:

* Serilog
* Request logging
* External API failure tracking
* Health checks

---

# 📐 Architectural Principles Followed

* Clean Architecture
* SOLID Principles
* Dependency Inversion
* Separation of Concerns
* Single Responsibility
* Interface-driven development

---

# 🧠 Design Decisions

* Infrastructure depends on Domain
* Application defines contracts
* API depends on Application
* No circular dependencies
* External services abstracted via interfaces

---

# 🧪 Testing (Planned)

Future:

* Unit tests for services
* Integration tests for controllers
* Mocking external API
* Test coverage tracking

---

# 🏁 Conclusion

WeatherApp is structured to:

* Scale easily
* Integrate cleanly with Angular
* Add features without breaking architecture
* Support external integrations
* Maintain high code quality

---
