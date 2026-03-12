# 🏆 ContestMaster Pro - Technical Submission

> **Note:** All source code and project files are located in the **main** branch.

A robust, full-stack Contest Management System built using **ASP.NET Core 7.0** and **Vanilla JavaScript**.

---

## 🚀 Live Demo & Source
* **Live Preview:** https://luxury-unicorn-63ffef.netlify.app/
* **Source Code:** https://github.com/akadkol05/ContestSystemTask

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
│   ├── Models/                     # Database Entities & DTOs
│   └── appsettings.json            # Connection Strings
│
├── wwwroot/                        # Frontend Application
│   ├── index.html                  # Main UI Entry Point
│   ├── script.js                   # API Integration
│   └── style.css                   # Custom UI Styling
│
├── ContestAPI.json                 # Postman Collection
└── README.md                       # Documentation
