# 🏆 ContestMaster Pro - Technical Submission

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


Gemini said
I see exactly what happened! In the screenshot, the bottom half of your README is getting sucked into the "Project Structure" code block. This is because a code block needs to be closed with three backticks (```) before you start a new section.

To fix this and make it look perfect, delete everything in your current README.md and paste this entire block below.

Markdown
# 🏆 ContestMaster Pro - Technical Submission

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
📸 Functionality Showcase
A. Secure Login & Dashboard
Authenticated entry point using JWT. The UI dynamically adapts based on the user's role.

B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Admin Database Management panel is unlocked, allowing for contest deletion.

C. Confirmation Safety Dialog
Built-in safety checks to prevent accidental data deletion.

D. API Protection (Rate Limiting)
The API includes a security layer that blocks excessive requests via custom middleware to ensure stability.

E. Normal User Experience
Standard users see a restricted view, showing only public contests without administrative tools.


Gemini said
I see the issue in your screenshot—the table and the code blocks for the commands are appearing as plain text because they are missing the correct Markdown syntax.

To make it look "Nice" (with the actual table borders and the gray boxes for code), you need to use the exact structure below.

Delete everything in your README and paste this entire block:

Markdown
# 🏆 ContestMaster Pro - Technical Submission

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
📸 Functionality Showcase
A. Secure Login & Dashboard
Authenticated entry point using JWT. The UI dynamically adapts based on the user's role.

B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Admin Database Management panel is unlocked, allowing for contest deletion.

C. Confirmation Safety Dialog
Built-in safety checks to prevent accidental data deletion.

D. API Protection (Rate Limiting)
The API includes a security layer that blocks excessive requests via custom middleware to ensure stability.

E. Normal User Experience
Standard users see a restricted view, showing only public contests without administrative tools.

🧪 API Endpoints & Postman Documentation
The project includes a ContestAPI.json for rapid testing. Import this into Postman to access:

Category	Endpoint	Method	Auth Required	Description
Auth	/api/auth/login	POST	Public	Get JWT Token & User Role
Auth	/api/auth/register	POST	Public	Create new account
Data	/api/contest	GET	Public	Fetch available contests
User	/api/contest/submit	POST	Bearer JWT	Submit quiz answers
Admin	/api/contest/admin/all-submissions	GET	Admin Only	View every user's entry
Admin	/api/contest/admin/delete-contest/{id}	DELETE	Admin Only	Remove a contest

Method 1: Visual Studio (Package Manager Console)

PowerShell
Update-Database
Method 2: Command Line (dotnet CLI)

Bash
cd ContestSystem.Api
dotnet ef database update
2. Launching the Project
Open ContestSystem.sln and set ContestSystem.Api as the startup project.

Press F5. The API defaults to https://localhost:44344.

⚠️ Important: Localhost Port Troubleshooting
If your local environment runs the project on a different port:

Open script.js in the wwwroot folder.

Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your specific port).

🛠️ Technical Highlights
Global Error Handling: Custom middleware catches server exceptions to return standardized JSON errors.

Security: JWT-based Auth + Custom Rate Limiting middleware.

Clean Code: Strict separation of concerns (Controllers -> Services -> Data).

🔑 Test Credentials
Admin: SuperAdmin / SecretPassword123!

User: NormalUser1 / UserPass123!
