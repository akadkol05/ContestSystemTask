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
<img width="1806" height="960" alt="image" src="https://github.com/user-attachments/assets/3e67c3d9-d016-47c3-b998-687d60cd890c" />

B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Database Management panel is unlocked.
<img width="1715" height="915" alt="image" src="https://github.com/user-attachments/assets/6b9da35e-b945-4104-9553-4d58dfeac349" />
<img width="1770" height="977" alt="image" src="https://github.com/user-attachments/assets/d5bd2ae7-b0a3-42dc-b1f8-17a6cf21273d" />


C. API Protection (Rate Limiting)
The API blocks excessive requests (3 hits/30s) to ensure stability.
<img width="1737" height="955" alt="image" src="https://github.com/user-attachments/assets/f2efce5f-98d4-42c7-90bf-a0c6cbb1189e" />

D.Normal User showing only normal contests
<img width="1828" height="692" alt="image" src="https://github.com/user-attachments/assets/96a9853d-b9e3-4ff5-8938-d7cd312b4d78" />


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
