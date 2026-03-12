I understand. The reason the "styling" (the bold headers, the clean lists, and the tables) isn't appearing is that GitHub requires a very specific spacing between blocks of code and text. If it's too cramped, it just displays as plain text.I have fixed the spacing in this version. Copy the entire block below and paste it into your README.md. It includes the Postman documentation, the migration commands, and all functionality screenshots.Markdown# 🏆 ContestMaster Pro - Technical Submission

A robust, full-stack Contest Management System designed with a focus on **Security**, **Scalability**, and **User Experience**. Built using **ASP.NET Core 7.0** and **Vanilla JavaScript**.

---

## 🚀 Live Demo & Source
* **Live Preview:** [https://luxury-unicorn-63ffef.netlify.app/](https://luxury-unicorn-63ffef.netlify.app/)
* **Source Code:** [https://github.com/akadkol05/ContestSystemTask](https://github.com/akadkol05/ContestSystemTask)

---

## 📁 Project Structure

```text
ContestMasterPro/
├── ContestSystem.sln               # Root Solution File
│
├── ContestSystem.Api/              # Backend Project (ASP.NET Core 7.0)
│   ├── Controllers/                # API Endpoints (Auth, Contests, Submissions)
│   ├── Data/                       # ApplicationDbContext & DB Configurations
│   ├── Migrations/                 # EF Core Schema & Seed History (Code-First)
│   ├── Middleware/                 # Custom Rate Limiting & Error Handling logic
│   ├── Models/                     # Database Entities & DTOs
│   └── appsettings.json            # Connection Strings & JWT Settings
│
├── wwwroot/                        # Frontend Application (Vanilla JS)
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration & Role Logic
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.json                 # Postman Collection (Import for API testing)
└── README.md                       # Documentation & Screenshots
📸 Functionality ShowcaseA. Secure Login & DashboardAuthenticated entry point using JWT. The UI dynamically adapts based on the user's role.B. Admin Management (Role-Based Access)Logged in as SuperAdmin, the red Admin Database Management panel is unlocked, allowing for contest deletion.C. Confirmation Safety DialogBuilt-in safety checks to prevent accidental data deletion.D. API Protection (Rate Limiting)The API includes a security layer that blocks excessive requests via custom middleware to ensure stability.E. Normal User ExperienceStandard users see a restricted view, showing only public contests without administrative tools.🧪 API Endpoints & Postman DocumentationThe project includes a ContestAPI.json for rapid testing. Import this into Postman to access:CategoryEndpointMethodAuth RequiredDescriptionAuth/api/auth/loginPOSTPublicGet JWT Token & User RoleAuth/api/auth/registerPOSTPublicCreate new accountData/api/contestGETPublicFetch available contestsUser/api/contest/submitPOSTBearer JWTSubmit quiz answersAdmin/api/contest/admin/all-submissionsGETAdmin OnlyView every user's entryAdmin/api/contest/admin/delete-contest/{id}DELETEAdmin OnlyRemove a contest🏃 Instructions to Run Locally1. Database Setup (EF Core Migrations)The project uses Code-First migrations to build the schema. No manual SQL scripts are required.Method 1: Visual Studio (Package Manager Console)PowerShellUpdate-Database
Method 2: Command Line (dotnet CLI)Bashcd ContestSystem.Api
dotnet ef database update
2. Launching the ProjectOpen ContestSystem.sln and set ContestSystem.Api as the startup project.Press F5. The API defaults to https://localhost:44344.⚠️ Important: Localhost Port TroubleshootingIf your local environment runs the project on a different port:Open script.js in the wwwroot folder.Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your specific port).🛠️ Technical HighlightsGlobal Error Handling: Custom middleware catches server exceptions to return standardized JSON errors.Security: JWT-based Auth + Custom Rate Limiting middleware.Clean Code: Strict separation of concerns (Controllers -> Services -> Data).🔑 Test CredentialsAdmin: SuperAdmin / SecretPassword123!User: NormalUser1 / UserPass123!
**Would you like me to draft the final submission email for you now?**
