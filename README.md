# PROG7311_Part2_POE

# Agri-Connect Web Platform

Agri-Connect is a web-based platform designed to connect South African farmers with green energy providers. The platform allows farmers to showcase their agricultural products, while employees or system administrators can manage data and monitor platform activity.

---

## 🌱 Table of Contents

- [Overview](#overview)
- [System Features](#system-features)
- [User Roles](#user-roles)
- [Technologies Used](#technologies-used)
- [Setting Up the Development Environment](#setting-up-the-development-environment)
- [How to Build and Run the Project](#how-to-build-and-run-the-project)
- [Sample Data & Images](#sample-data--images)
- [Contact & Support](#contact--support)

---

## 📝 Overview

This platform offers a sustainable digital space where:
- **Farmers** can register, add products, and upload images.
- **Employees** can view all products, filter by category/date, and manage data.

---

## ⚙️ System Features

- Farmer registration and login.
- Product upload with category, production date, and image.
- Viewing of products by all users.
- Filtering products by category and date range.
- Admin/Employee role with access to view all farmer data.

---

## 👥 User Roles

| Role       | Description |
|------------|-------------|
| **Farmer** | Can register, log in, and upload/view their own products. |
| **Employee** | Has permission to view all farmer products and access filtering tools. |

---

## 🛠 Technologies Used

- **ASP.NET Core MVC** – Web application framework
- **Entity Framework Core** – ORM for database access
- **SQLite / SQL Server** – Database
- **Bootstrap** – Styling and responsive UI
- **Razor Pages** – View rendering
- **Identity** – User authentication & roles

---

## 🧰 Setting Up the Development Environment

Follow these steps to get started:

### 1. Clone the Repository
```bash
git clone https://github.com/your-org/agri-connect.git
cd agri-connect
2. Install Prerequisites
Ensure you have the following installed:

.NET SDK 7+

Visual Studio Code or Visual Studio

(Optional) SQL Server or SQLite

3. Configure the Database
Update your appsettings.json file with a valid connection string.

Example (using SQLite):

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Data Source=agri-connect.db"
}
4. Apply Migrations & Seed Data
bash
Copy
Edit
dotnet ef database update
Seeder classes will automatically populate:

1 employee (with role)

2 farmers

Sample products with images (wwwroot/images)

▶️ How to Build and Run the Project
1. Build the Project
bash
Copy
Edit
dotnet build
2. Run the Application
bash
Copy
Edit
dotnet run
3. Access the Web App
Open your browser and navigate to:

arduino
Copy
Edit
https://localhost:5001
🧪 Sample Credentials
Employee Login
Email: employee@agriplatform.com

Password: P@ssword123

Farmer Login
Email: farmer1@example.com

Password: P@ssword123

🖼 Sample Data & Images
Sample images are stored in: wwwroot/images/

Images are linked to products in the seed data.

💬 Contact & Support
For questions, feedback, or support:

📧 Email: support@agriplatform.com

📞 Phone: +27 123 456 789

© 2025 Agri-Connect. All rights reserved.

yaml
Copy
Edit

---

Let me know if you’d like:
- To generate this as a downloadable `.md` file.
- Separate credentials per seeded user.
- Instructions for Docker support or deployment.