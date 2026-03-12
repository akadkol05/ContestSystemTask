🏆 ContestMaster Pro - Technical Submission
A robust, full-stack Contest Management System designed with a focus on Security, Scalability, and User Experience. Built using ASP.NET Core 7.0 and Vanilla JavaScript.

🚀 Live Demo & Source
Live Preview: https://luxury-unicorn-63ffef.netlify.app/

Source Code: https://github.com/akadkol05/ContestSystemTask

📁 Project Structure
Plaintext
ContestSystemTask/
├── ContestSystem.sln               # Root Solution File
│
├── ContestSystem.Api/              # Backend Project (ASP.NET Core 7.0)
│   ├── Controllers/                # API Endpoints (Auth, Contests, Submissions)
│   ├── Data/                       # ApplicationDbContext & DB Configurations
│   ├── Migrations/                 # EF Core Schema & Seed History
│   ├── Middleware/                 # Custom Rate Limiting & Error Handling logic
│   ├── Models/                     # Database Entities & DTOs
│   └── appsettings.json            # Connection Strings & JWT Settings
│
├── wwwroot/                        # Frontend Application (Vanilla JS)
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration & Role Logic
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.txt                  # Postman Collection (Rename to .json)
└── README.md                       # Documentation & Screenshots
📸 Functionality Showcase
A. Secure Login & Dashboard
Authenticated entry point. The system uses JWT tokens to manage sessions and identify user roles.

B. Admin Management (Role-Based Access)
When logged in as SuperAdmin, the red Database Management panel is dynamically unlocked, allowing for contest deletion.

C. API Protection (Rate Limiting)
Custom middleware blocks excessive requests (Limit: 3 hits per 30 seconds) to ensure API stability and prevent brute-force attacks.

D. Normal User Experience
Standard users are restricted from administrative views and can only participate in eligible contests.

🏃 Instructions to Run Locally
1. Database Setup (Migrations)
The project uses Entity Framework Core Migrations to handle schema creation and seeding.

Using Visual Studio:

Update DefaultConnection in appsettings.json to your local SQL Server instance.

Open Package Manager Console.

Run: Update-Database

Using Command Line (dotnet CLI):

Navigate to the ContestSystem.Api folder.

Run:

Bash
dotnet ef database update
2. Launching the Project
Open ContestSystem.sln and set ContestSystem.Api as the startup project.

Press F5. The API defaults to https://localhost:44344.

⚠️ Important: Localhost Port Troubleshooting
If your environment runs the project on a different port:

Open script.js in the wwwroot folder.

Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your port).

Refresh the browser.

🛠️ Technical Highlights
JWT Auth: Secure authentication with role-based claims.

Global Error Handling: Custom middleware to return standardized JSON error responses.

Code-First Migrations: Fully versioned database schema.

Security: Implemented Rate Limiting on critical endpoints.

🔑 Test Credentials
Admin: SuperAdmin / SecretPassword123!

User: NormalUser1 / UserPass123!

🧪 Postman Documentation
Import ContestAPI.txt (rename to .json) into Postman. It includes pre-configured headers for JWT authentication and tests for the rate-limiting middleware.
