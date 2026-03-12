
# 🏆 ContestMaster Pro 

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

```

---

## 📸 Functionality Showcase

### A. Secure Login & Dashboard

Authenticated entry point using JWT. The UI dynamically adapts based on the user's role (Admin vs. User).

---

### B. Admin Management (Role-Based Access)

When logged in as **SuperAdmin**, the restricted **Admin Database Management** panel is visible, allowing for full control over contest data.

---

### C. Confirmation Safety Dialog

To prevent data loss, the system includes a custom modal confirmation before any contest is permanently deleted.

---

### D. API Protection (Rate Limiting)

Security middleware prevents brute-force attacks by limiting users to **3 requests per 30 seconds**.

---

### E. Normal User Experience

Standard users are restricted to a simplified view where they can only participate in active contests.

---

## 🧪 API Endpoints (Postman Documentation)

| Category | Endpoint | Method | Auth Required | Description |
| --- | --- | --- | --- | --- |
| **Auth** | `/api/auth/login` | `POST` | Public | Get JWT Token & User Role |
| **Auth** | `/api/auth/register` | `POST` | Public | Create new account |
| **Data** | `/api/contest` | `GET` | Public | Fetch available contests |
| **User** | `/api/contest/submit` | `POST` | **Bearer JWT** | Submit quiz answers |
| **Admin** | `/api/contest/admin/all-submissions` | `GET` | **Admin Only** | View every user's entry |
| **Admin** | `/api/contest/admin/delete-contest/{id}` | `DELETE` | **Admin Only** | Remove a contest |

---

## 🏃 Instructions to Run Locally

### 1. Database Setup (Migrations)

Run these commands to generate the local database:

**Method 1: Visual Studio (Package Manager Console)**

```powershell
Update-Database

```

**Method 2: Command Line (dotnet CLI)**

```bash
cd ContestSystem.Api
dotnet ef database update

```

---

### 2. Launching the Project

1. Open `ContestSystem.sln`.
2. Set `ContestSystem.Api` as startup project.
3. Press **F5**. (Default Port: `44344`).

---

## 🔑 Test Credentials

* **Admin:** `SuperAdmin` / `SecretPassword123!`
* **User:** `NormalUser1` / `UserPass123!`

```



```
