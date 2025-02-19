Patient Registration System

Overview
The Patient Registration System is a web-based application developed using ASP.NET Core MVC, Entity Framework Core, 
and Bootstrap 5. It allows users to manage patient records efficiently, 
including searching, filtering, creating, editing, and soft deleting patient entries.

Features
Patient Management: Create, edit, view, and soft-delete patient records.
Advanced Search & Filtering: Search by full name and filter by gender.
SweetAlert2 Notifications: Success and error messages appear as toast alerts.
Soft Delete: Patients are marked as deleted instead of being permanently removed.

Technologies Used
ASP.NET Core 8 MVC
Entity Framework Core (EF Core) for database management
MySQL Server as the database
Bootstrap 5 for responsive design
Font Awesome for icons
SweetAlert2 for user-friendly notifications


Installation & Setup
1. Prerequisites
Ensure you have the following installed:
.NET 8 SDK
MySQL Server
Visual Studio Code or Visual Studio 2022

2. Clone the Repository
git clone https://github.com/cadota02/PatientRegistrationSystem.git
cd PatientRegistrationSystem

4. Configure Database
Open appsettings.json and update the database connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=PatientDB;Trusted_Connection=True;"
}

Apply migrations and update the database using terminal:
dotnet ef database update

4. Run the Application using terminal:
dotnet run
Then, open http://localhost:5129 in your browser.


Usage Guide

Add a Patient: Click the Create Patient button, fill out the form, and submit.
Edit a Patient: Click the Edit button, modify details, and save changes.
Search & Filter:  Click the Advance Search button, search box to find patients by full name, or use the gender filter.
Soft Delete: Click the Trash icon, confirm deletion via the modal, and the record will be hidden.
View Patient Details: Click the View Details button to see complete patient information.

