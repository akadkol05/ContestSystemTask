Contest Participation System API
A professional, role-based RESTful API built with ASP.NET Core 7.0 and Entity Framework Core. This system manages contest lifecycles, real-time scoring logic, and user leaderboards with tiered access for Guests, Normal Users, and VIPs.

Key Features
1. Advanced Authentication & Authorization
JWT Bearer Tokens: Secure identity management and session handling.

Role-Based Access Control (RBAC):

Guest: Can view public contest metadata.

Normal User: Can participate in "Normal" contests.

VIP User: Full access to high-stakes "VIP" contests and exclusive prizes.

2. Contest & Question Engine
Flexible Question Types: Logic built for Single-select, Multi-select, and True/False questions.

Automatic Scoring: Real-time calculation upon submission by comparing user answers against database records.

Optimized Queries: Uses Eager Loading (.Include()) to fetch questions and options in a single database round-trip.

3. Leaderboard & User History
Global Ranking: A dynamic leaderboard calculated via LINQ grouping and aggregation.

User Dashboard: Participants can track their history of joined contests, scores, and prizes won.

4. Enterprise-Grade Stability
Rate Limiting: Implemented Fixed-Window Limiting (10 requests / 10 seconds) to prevent API abuse.

Global Error Handling: Clean, structured JSON responses for edge cases (401, 403, 400).

Code-First Migrations: Fully versioned database schema management.

Technical Stack
Framework: .NET 7.0 Web API

ORM: Entity Framework Core

Database: Microsoft SQL Server (SQLEXPRESS / LocalDB)

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
Via Visual Studio (IIS Express)
Open ContestSystem.sln in Visual Studio 2022.

Ensure IIS Express (the green play button) is selected in the toolbar.

Press F5. The browser will launch the Swagger UI at /swagger/index.html.

Via .NET CLI
PowerShell
dotnet run
3. Data Seeding
The system includes an automatic DbSeeder that populates the database on the first run with:

Normal Contest: "General Knowledge Quiz"

VIP Contest: "Crypto Masters VIP"

Pre-configured questions, options, and correct answers.

Testing with Postman
The Postman Collection is included in the root of this repository as:
ContestSystem.postman_collection.json.

Testing Workflow:

Import: Drag the .json file into Postman.

Register: Create a user (Role: Normal or VIP).

Login: Copy the token from the response.

Authorize: In other requests, go to the Auth tab, select Bearer Token, and paste your token.

 Project Structure
/Controllers: API endpoints for Authentication, Contest retrieval, and Submissions.

/Models: Database entities (User, Contest, Question, Option, Submission).

/Data: AppDbContext, Migrations, and DbSeeder.

/DTOs: Data Transfer Objects for decoupled request/response handling.
