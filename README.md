# ContestSystemTask
A robust, role-based RESTful API built with ASP.NET Core 7.0 and Entity Framework Core. This system manages contest lifecycles, real-time scoring logic, and user leaderboards with tiered access for Guest, Normal, and VIP users.

Key Features
1. Advanced Authentication & Authorization
JWT Bearer Tokens: Secure identity management.

Role-Based Access Control (RBAC): * Guest: Can view public contest metadata only.

Normal User: Can participate in "Normal" contests.

VIP User: Full access to high-stakes "VIP" contests and prizes.

2. Contest & Question Engine
Support for Multiple Types: Single-select, Multi-select, and True/False questions.

Automatic Scoring: Real-time calculation of scores upon submission by comparing user answers against encrypted database options.

Navigation Properties: Optimized SQL queries using .Include() to fetch nested questions and options in a single database round-trip.

3. Leaderboard & User History
Ranking System: Global leaderboard calculated via LINQ grouping.

Personal Dashboard: Users can track their participation history and prizes won.

4. Enterprise-Grade Stability
Rate Limiting: Implemented fixed-window limiting (10 requests per 10 seconds) to prevent brute-force attacks and API abuse.

Global Error Handling: Structured JSON responses for all edge cases (401 Unauthorized, 403 Forbidden, 400 Bad Request).

Database Migrations: Fully versioned schema using EF Core Migrations.

Technical Stack
Framework: .NET 7.0 Web API

ORM: Entity Framework Core

Database: Microsoft SQL Server (LocalDB / SQLEXPRESS)

Security: JWT (System.IdentityModel.Tokens.Jwt), BCrypt.Net (Password Hashing)

Documentation: Swagger / OpenAPI

Getting Started
1. Database Setup
Update the connection string in appsettings.json to point to your local SQL instance:

JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ContestSystem;Trusted_Connection=True;TrustServerCertificate=True;"
}
Apply the migrations to create the schema:

PowerShell
dotnet tool run dotnet-ef database update
2. Running the Application
Press F5 in Visual Studio or run:

PowerShell
dotnet run
The API will launch at https://localhost:44344/swagger/index.html.

3. Data Seeding
The system includes a DbSeeder class that automatically populates the database with:

A Normal Contest (General Knowledge)

A VIP Contest (Crypto Masters)

Sample questions and correct answers.

Testing with Postman
A Postman Collection is included in the repository.

Register a new user with the role "Normal" or "VIP".

Login to receive your JWT Token.

In all subsequent requests, add the token under Authorization > Bearer Token.

Project Structure
/Controllers: API endpoints for Auth and Contests.

/Models: Database entities (User, Contest, Question, Submission).

/Data: DbContext and Seeding logic.

/DTOs: Data Transfer Objects for clean API request/response handling.
