📋 Copy this ENTIRE block for your README:Markdown# 🏆 ContestMaster Pro - Technical Submission

> **Note:** All source code and project files are located in the **main** branch.

A robust, full-stack Contest Management System built using **ASP.NET Core 7.0** and **Vanilla JavaScript**.

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
├── ContestSystem.Api/              # Backend Project
│   ├── Controllers/                # API Endpoints
│   ├── Data/                       # DbContext & Configurations
│   ├── Migrations/                 # EF Core Schema & Seed History
│   ├── Middleware/                 # Rate Limiting & Error Handling
│   └── Models/                     # Database Entities & DTOs
│
├── wwwroot/                        # Frontend Application
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.json                 # Postman Collection
└── README.md                       # Documentation
📸 Functionality Showcase## A. Secure Login & DashboardAuthenticated entry point using JWT. The UI dynamically adapts based on the user's role (Admin vs. User).## B. Admin Management (Role-Based Access)When logged in as SuperAdmin, the restricted Admin Database Management panel is visible, allowing for full control over contest data.## C. Confirmation Safety DialogTo prevent data loss, the system includes a custom modal confirmation before any contest is permanently deleted.## D. API Protection (Rate Limiting)Security middleware prevents brute-force attacks by limiting users to 3 requests per 30 seconds.## E. Normal User ExperienceStandard users are restricted to a simplified view where they can only participate in active contests.🧪 API Endpoints (Postman Collection)CategoryEndpointMethodAuth RequiredDescriptionAuth/api/auth/loginPOSTPublicGet JWT TokenAuth/api/auth/registerPOSTPublicCreate new accountContest/api/contestGETPublicFetch available contestsUser/api/contest/submitPOSTJWT RequiredSubmit quiz answersAdmin/api/contest/admin/all-submissionsGETAdmin OnlyView user resultsAdmin/api/contest/admin/delete-contest/{id}DELETEAdmin OnlyRemove a contest🏃 Instructions to Run Locally### 1. Database Setup (Migrations)Run these commands to generate the local database:Visual Studio: Update-DatabaseTerminal: dotnet ef database update### 2. Launching the ProjectOpen ContestSystem.sln.Set ContestSystem.Api as startup project.Press F5. (Default Port: 44344).🔑 Test CredentialsAdmin: SuperAdmin / SecretPassword123!User: NormalUser1 / UserPass123!
**Does the showcase section look properly separated now?** If so, I can help with the email draft!
