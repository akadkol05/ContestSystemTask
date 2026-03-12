# 🏆 ContestMaster Pro - Technical Submission

A robust, full-stack Contest Management System designed with a focus on **Security**, **Scalability**, and **User Experience**. Built using **ASP.NET Core 7.0** and **Vanilla JavaScript**.

---

## 🚀 Live Demo & Source
* **Live Preview:** [https://luxury-unicorn-63ffef.netlify.app/](https://luxury-unicorn-63ffef.netlify.app/)
* **Source Code:** [https://github.com/akadkol05/ContestSystemTask](https://github.com/akadkol05/ContestSystemTask)

---

## 📁 Project Structure
```text
ContestSystemTask/
├── ContestSystem.sln               # Root Solution File
│
├── ContestSystem.Api/              # Backend Project (ASP.NET Core 7.0)
│   ├── Controllers/                # API Endpoints
│   ├── Data/                       # DbContext & Configurations
│   ├── Migrations/                 # EF Core Schema & Seed History
│   ├── Middleware/                 # Rate Limiting & Error Handling
│   ├── Models/                     # Database Entities & DTOs
│   └── appsettings.json            # Connection Strings
│
├── wwwroot/                        # Frontend Application
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration & Role Logic
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.json                 # Postman Collection
└── README.md                       # Documentation & Screenshots

Gemini said
I understand—it’s frustrating when you want it to look sharp and the formatting keeps getting messed up.

Markdown on GitHub doesn't support custom CSS/styles (like colors or font-weights) directly in a README. It only supports Standard Markdown. If you are trying to copy-paste the "colored" version from our chat, it will lose the colors because GitHub strips them.

To get the best possible look on GitHub that won't break, use the "Raw" code below. I have used Standard GitHub Markdown (tables, code blocks, and bolding) which GitHub is designed to render perfectly.

Paste this EXACTLY into your README.md:
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
ContestSystemTask/
├── ContestSystem.sln               # Root Solution File
│
├── ContestSystem.Api/              # Backend Project (ASP.NET Core 7.0)
│   ├── Controllers/                # API Endpoints
│   ├── Data/                       # DbContext & Configurations
│   ├── Migrations/                 # EF Core Schema & Seed History
│   ├── Middleware/                 # Rate Limiting & Error Handling
│   ├── Models/                     # Database Entities & DTOs
│   └── appsettings.json            # Connection Strings
│
├── wwwroot/                        # Frontend Application
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration & Role Logic
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.json                 # Postman Collection
└── README.md                       # Documentation & Screenshots
📸 Functionality Showcase
A. Secure Login & Dashboard
Authenticated entry point using JWT. The UI dynamically adapts based on the user's role.

B. Admin Management (Role-Based Access)
Logged in as SuperAdmin, the red Database Management panel is unlocked, allowing for contest deletion.

C. API Protection (Rate Limiting)
The API blocks excessive requests (3 hits per 30 seconds) via custom middleware to ensure stability.

D. Normal User Experience
Standard users are restricted from administrative views and can only see eligible contests.

🛠️ Technical Highlights
JWT Authentication: Secure, token-based login with role-based claims.

Global Error Handling: Middleware catches server exceptions to return clean JSON.

Custom Rate Limiting: Prevents API abuse (Limit: 3 requests per 30 seconds).

🏃 Instructions to Run Locally
1. Database Setup (Migrations)
The project uses EF Core Migrations. No manual SQL scripts are required.

Visual Studio: Open Package Manager Console and run Update-Database.

CLI: Navigate to ContestSystem.Api and run dotnet ef database update.

2. Launching the Project
Open ContestSystem.sln and set ContestSystem.Api as startup project.

Press F5. The API defaults to https://localhost:44344.

⚠️ Important: Localhost Port Troubleshooting
If your local environment runs on a different port:

Open script.js in wwwroot.

Change the first line: const API = "https://localhost:XXXX/api"; (Replace XXXX with your port).

🔑 Test Credentials
Admin: SuperAdmin / SecretPassword123!

User: NormalUser1 / UserPass123!
