🏆 ContestMaster Pro - Technical Submission
A robust, full-stack Contest Management System designed with a focus on Security, Scalability, and User Experience. Built using ASP.NET Core 7.0 and Vanilla JavaScript.

🚀 Live Demo & Source
Live Preview: https://luxury-unicorn-63ffef.netlify.app/

Source Code: https://github.com/akadkol05/ContestSystemTask

🛠️ Technical Stack & Features
1. Backend Architecture (ASP.NET Core 7.0)
Clean Architecture: Separation of concerns between Controllers, Services, and Data layers.

JWT Authentication: Secure, token-based login system with role claims.

Global Error Handling: Middleware catches server errors and returns clean JSON responses.

Custom Rate Limiting: Middleware to prevent API abuse (Limit: 3 requests per 30 seconds).

2. Frontend Logic (Vanilla JS & Bootstrap)
Role-Based UI: Interface dynamically renders based on the user's role (Admin vs. User).

State Management: Securely handles JWT storage and session persistence.

Asynchronous Operations: Clean fetch calls with try/catch error handling.

📸 Functionality Showcase
A. Secure Login & Dashboard
B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Database Management panel is unlocked.

C. API Protection (Rate Limiting)
The API blocks excessive requests (3 hits/30s) to ensure stability.

🏃 Instructions to Run Locally
1. Database Setup
Update DefaultConnection in appsettings.json to your local SQL Server instance.

In Package Manager Console, run: Update-Database.

(Optional) Use the Database_Setup.sql file in the root to manually execute schema and seed data.

2. Launching the Project
Open ContestSystem.sln and set ContestSystem.Api as the startup project.

Press F5. The API defaults to https://localhost:44344.

⚠️ Important: Localhost Port Troubleshooting
If your Visual Studio runs the project on a different port (e.g., 5000 or 7200):

Open script.js in the root folder.

Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your port).

Refresh the browser.

🔑 Test Credentials
Admin: SuperAdmin / SecretPassword123!

User: NormalUser1 / UserPass123!

🧪 Postman Documentation
Import ContestAPI.txt (rename to .json) into Postman. It includes pre-configured headers for JWT authentication and tests for the rate-limiting middleware.
