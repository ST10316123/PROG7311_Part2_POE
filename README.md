# PROG7311_Part2_POE

# Agri-Connect Web Platform

Agri-Connect is a web-based platform designed to connect South African farmers with green energy providers. The platform allows farmers to showcase their agricultural products, while employees or system administrators can manage data and monitor platform activity. This Readme file contains all the necessary information about the features of this program, what are the requriements and how to run it 

---

## 🌱 Table of Contents
- [System features](#system-features)
- [User Roles](#user-roles)
- [Technologies Used](#technologies-used)
- [Setting Up the Development Environment](#setting-up-the-development-environment)
- [How to Build and Run the Project](#how-to-build-and-run-the-project)


---

## ⚙️ System Features (Functional Requirements)

- Employee login.
- Farmer registration and login.
- Product upload with category, production date, and an image.
- Farmer viewing their added products.
- Employee viewing list of all products added by farmers.
- Filtering products by category and date range.


---

## 👥 User Roles

| Role       | Description |
|------------|-------------|
| **Farmer** | Can log in, and upload/view their own products. |
| **Employee** | Has permission to view all farmer products and filter list via category or date range. |

---

## 🛠 Technologies Used

- **ASP.NET Core MVC** – Web application framework
- **Entity Framework Core** – For database access
- **Microsoft SQL Server Management Studio / SQL Server** – Database where all the data is stored
- **Visual Studio Code** – IDE for creating and running the MVC code
- **Identity** – User authentication & roles
- **GitHub Desktop** - Clone the repository from GitHub (optional)

---

## 🧰 Setting Up the Development Environment

Follow these steps to get started:

### 1. Install Prerequisites
Ensure you have the following programs installed:
```bash

1) Visual Studio Code

2) .NET SDK 7+ version

3) MSSQL or SQL Server

4) GitHub Desktop (optional)

```

### 2. Clone the Repository

#### Option 1
```bash
git clone https: https://github.com/VCWVL/prog7311-part-2-ST10316123.git
cd agri-connect
```


#### Option 2
```bash
Open GitHub Desktop
Clone repository with this URL : https://github.com/VCWVL/prog7311-part-2-ST10316123.git
Click on 'Open in Visual Studio Code'

```

### 3. Install the ffg dependencies

In the Visual Studio Code Terminal, add the ffg packages:
```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools


```


### 4. Update your appsettings.json file with a valid connection string.
Example: 
```bash




"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AgriConnectDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

**Save changes therafter



### 5. Ensure the ffg lines in the program.cs file are not commented out
```bash

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var context = services.GetRequiredService<ApplicationDbContext>();
    var env = services.GetRequiredService<IWebHostEnvironment>();

    // Call the seeders to add the data
    await EmployeeSeeder.SeedAsync(userManager, roleManager);
    await FarmerSeeder.SeedAsync(userManager, roleManager);
    await ProductSeeder.SeedAsync(context, userManager, env);
}

```
**Save all changes and thereafter run the ffg command:

```bash
dotnet ef database update
dotnet run

```

### 6. Check that the database is created along with the tables and sample data
```bash
1. Open MSSMS
2. Connect to local server : (localdb)\\mssqllocaldb;
3. Under Databases folder head to the AgriConnectDB > Tables > Products
4. Right-click on Products and click on the 'Select Top 1000 rows' option
5. Ensure that the table is filled with sample data 

```
---

## ▶️ How to Build and Run the Project
### 1. Build the Project
```bash
dotnet build
```


### 2. Run the Application
```bash
dotnet run
```


### 3. Access the Web App
Open your browser and navigate to:
```bash
http://localhost:5103/
```


### 4. 🧪 Sample Credentials for logging in
## These details are present in the Employee and Farmer Seeder classes
```bash
Employee Login
Email: admin@farmershub.com
Password: Admin123!
```
```bash
Farmer 1 Login
Email: John@mail.com
Password: Farmer123!
```
```bash
Farmer 2 Login
Email: Jane@mail.com
Password: Farmer123!

```


### 5. 🖼 Sample Data & Images
Sample images are stored in: 
```bash
wwwroot/images/
```

Images are linked to products in the seed data.


### 6. 👨‍🌾 Access the Farmer Product List
Log in using any Farmer credentials (see Sample Credentials above) to:
```bash
1) Add new products.

2) View a list of your own uploaded products.
```

### 7. 🧑‍💼 Access All Farmer Products (Employee View)
Log in using the Employee credentials to:
```bash
1) View the complete list of products uploaded by all farmers.

2) Access filter functionality to refine the product list.
```

### 8. 🔍 Test the Product Filter Feature
Once logged in as an Employee, test the filtering functionality:
```bash
✅ Filter by Category – Select a category from the dropdown.

✅ Filter by Date Range – Specify a start and/or end production date.

Click the "Filter" button to apply filters.

To reset and view all products again:

Click the "Reset" or clear the form and submit again.
```
---

## Author
**Abdul Basit Deshmukh**

---

## References
- Basic writing and formatting syntax (no date) GitHub Docs. Available at: https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax (Accessed: 14 May 2025). 
- Dykstra, T. et al. (2024) Tutorial: Get started with EF Core in an ASP.NET MVC web app, Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0 (Accessed: 14 May 2025). 
- Saini, V.K. (2023) Upload and display image in MVC Application, C# Corner. Available at: https://www.c-sharpcorner.com/UploadFile/b696c4/how-to-upload-and-display-image-in-mvc/ (Accessed: 14 May 2025). 
- Singh, R. (2024) Learn github-flavored Markdown syntax and formatting – with examples, freeCodeCamp.org. Available at: https://www.freecodecamp.org/news/github-flavored-markdown-syntax-examples/ (Accessed: 14 May 2025). 
- Vickers, A. et al. (2024) Identity model customization in ASP.NET Core, Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-9.0 (Accessed: 14 May 2025). 
- Wagner, B. and Oyetubo, O. (2025) Introduction to LINQ queries - C#, Introduction to LINQ Queries - C# | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries (Accessed: 14 May 2025). 
- Wagner, B., Deschryver, T. and Buibao, L. (2024) Standard query operators Overview - C#, C# | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/ (Accessed: 14 May 2025). 
- Zang, A. (2024) ASP.NET Core Basics: Getting started with Linq, Telerik Blogs. Available at: https://www.telerik.com/blogs/asp-net-core-basics-getting-started-linq (Accessed: 14 May 2025). 

