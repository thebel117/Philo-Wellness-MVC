Philo Wellness

Philo Wellness (named for Saint Philomena) is a web application designed to manage and track student wellness data for school nurses' offices. The application allows users to record and review wellness ratings, manage student profiles, and track visit records.

Features

-  Student Profiles : Create and manage student profiles, including personal details and wellness history.
-  Wellness Ratings : Record and track wellness ratings from both students and faculty.
-  Visit Records : Log student visits to the nurse's office and review historical data.
-  User Management : Differentiate between student and faculty users, ensuring appropriate access and functionality.

Technologies

-  ASP.NET Core MVC : For building the web application.
-  Entity Framework Core : For database management and data access.
-  AutoMapper : For mapping between entities and view models.
-  Bootstrap : For styling and responsive design.

Installation
----------------------------------------------------------------------------------
Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Steps

1.  Clone the repository :

2.  Navigate to the project directory :
   cd PhiloWellness

3.  Restore dependencies :
   dotnet restore

4.  Apply database migrations :
   dotnet ef database update

5.  Run the application :
   dotnet run

   or for automatic reload on changes:

   dotnet watch run
----------------------------------------------------------------------------------------------------
Usage

-  Home : Welcome page with links to different sections of the application.
-  Student Profiles : Manage student data, including creating, editing, and deleting profiles.
-  Wellness Ratings : View and manage wellness ratings. Add new ratings and review past ratings.
-  Visit Records : Log new visits and review past visits to the nurse's office.

   Navigation

Use the links on the home page to access the different views and functions of the application.

  Project Structure

PhiloWellness/
├── Controllers/           Handles HTTP requests and responses
├── Data/                  Database context and entity configurations
├── Models/                View models and entity models
├── Services/              Business logic and data manipulation
├── Views/                 Razor views for the UI
├── wwwroot/               Static files like CSS, JS, and images
├── Program.cs             Application entry point
└── Startup.cs             Configuration and service registration


  Contributing

Contributions are welcome-- While Philo is still very young and needing a lot of work, but with enough hopefully she will be something useful for people who need her. :)