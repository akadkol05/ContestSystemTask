🏆 ContestMaster Pro - Technical Submission
A robust, full-stack Contest Management System designed with a focus on Security, Scalability, and User Experience. Built using ASP.NET Core 7.0 and Vanilla JavaScript.

🚀 Live Demo & Source
Live Preview: https://luxury-unicorn-63ffef.netlify.app/

Source Code: https://github.com/akadkol05/ContestSystemTask

📁 Project Structure
ContestSystemTask/
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
├── ContestAPI.txt                  # Postman Collection (Rename to .json)
└── README.md                       # Documentation & Screenshots

📸 Functionality Showcase

A. Secure Login & Dashboard
<img width="1806" height="960" alt="image" src="https://github.com/user-attachments/assets/3e67c3d9-d016-47c3-b998-687d60cd890c" />

B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Database Management panel is unlocked, providing full administrative control.
<img width="1715" height="915" alt="image" src="https://github.com/user-attachments/assets/6b9da35e-b945-4104-9553-4d58dfeac349" />
<img width="1770" height="977" alt="image" src="https://github.com/user-attachments/assets/d5bd2ae7-b0a3-42dc-b1f8-17a6cf21273d" />


C. API Protection (Rate Limiting)
The API blocks excessive requests (3 hits per 30 seconds) via custom middleware to ensure system stability.
<img width="1737" height="955" alt="image" src="https://github.com/user-attachments/assets/f2efce5f-98d4-42c7-90bf-a0c6cbb1189e" />

D. Normal User Experience
Standard users are presented with a streamlined view, showing only public competitions without administrative tools.
<img width="1828" height="692" alt="image" src="https://github.com/user-attachments/assets/96a9853d-b9e3-4ff5-8938-d7cd312b4d78" />


🏃 Instructions to Run Locally
1. Database Setup
Update DefaultConnection in appsettings.json to your local SQL Server instance.


Method 1: Visual Studio (GUI)

Update DefaultConnection in appsettings.json to your local SQL Server instance.

Open Package Manager Console.

Run: Update-Database

Method 2: Command Line (dotnet CLI)

Navigate to the ContestSystem.Api folder in your terminal.

Run:

Bash
dotnet ef database update
2. Launching the Project
Open ContestSystem.sln and set ContestSystem.Api as the startup project.

Press F5. The API defaults to https://localhost:44344.

⚠️ Important: Localhost Port Troubleshooting
If your local environment runs the project on a different port (e.g., 5000 or 7200):

Open script.js in the wwwroot folder.

Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your specific port).

Refresh the browser.

🛠️ Technical Highlights
Global Error Handling: Custom middleware catches all server exceptions to return clean, standardized JSON errors.

Security: JWT-based Auth + Custom Rate Limiting middleware.

Clean Code: Separation of Concerns (Controllers -> Services -> Data).

🔑 Test Credentials
Admin: SuperAdmin / SecretPassword123!

User: NormalUser1 / UserPass123!

🧪 Postman Documentation
Import ContestAPI.txt (rename to .json) into Postman. It contains pre-configured headers for JWT authentication and pre-written tests for the rate-limiting logic.

🧪 API Documentation & Postman TestingThe backend API is fully documented and includes a Postman collection for automated testing.How to test the API:Locate ContestAPI.json in the root folder.Import the file into Postman.The collection uses a dynamic variable {{token}}. When you run the "Admin Login" or "Normal User Login" request, the collection automatically saves the JWT token for all subsequent protected requests.Key API Endpoints:CategoryEndpointMethodAuth RequiredDescriptionAuth/api/auth/registerPOSTNoRegister a new userAuth/api/auth/loginPOSTNoGet JWT Token & User RoleData/api/contestGETNoView all active contestsData/api/contest/leaderboardGETNoView global rankingsUser/api/contest/submitPOSTUser/AdminSubmit quiz answersUser/api/contest/my-historyGETUser/AdminView personal resultsAdmin/api/contest/admin/all-submissionsGETAdmin OnlyView every user's entryAdmin/api/contest/admin/delete-contest/{id}DELETEAdmin OnlyRemove a contest3. Add this under your "Technical Highlights" (Security Section):Automated Testing: Postman scripts are included that automatically extract the JWT token from login responses and apply it to the Bearer Authentication header for all protected endpoints.Role Validation: The API enforces strict backend validation. For example, if a Normal User attempts to call the DELETE endpoint, the system returns a 403 Forbidden error, even if they have a valid token.Final Pro-Tip for your Submission:Since you have the JSON code for the Postman collection:Create a new file in your project root called ContestAPI.json.Paste that JSON code into it.Delete the old ContestAPI.txt. Using a .json extension is much more professional and allows the recruiter to import it with one click.
