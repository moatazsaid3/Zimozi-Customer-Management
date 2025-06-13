# Customer Management Razor Pages Project

This is a demo application for managing customers, built with ASP.NET Core (.NET 8), Entity Framework Core, and Telerik Kendo UI components.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local or remote)
- [Node.js](https://nodejs.org/) (optional, for client-side package management)
- Visual Studio 2022 or later (recommended)

## Getting Started


### 2. Configure the Database

Update the `DefaultConnection` string in `appsettings.json` to point to your SQL Server instance:

### 3. Apply Database Migrations

Open a terminal in the project directory and run: dotnet ef database update

This will create the create the tables and insert seed data in the customer table.

### 4. Restore Dependencies

Restore NuGet packages:

### 5. Build and Run the Project

You can run the project using Visual Studio (__F5__ or __Ctrl+F5__), or from the command line:

The application will start and be accessible at `http://localhost:5249/Login` or the port specified in the output.
(LOGIN CREDENTIALS USERNAE: admin PASSWORD: admin)

## Features

- Customer CRUD operations with Kendo UI Grid
- Server-side validation and client-side validation (jQuery Unobtrusive)
- Basic authentication filter applied globally (LOGIN CREDENTIALS USERNAE: admin PASSWORD: admin)
- Session management
- Export to Excel and PDF

## Notes

- Telerik Kendo UI requires a valid license. Ensure your environment is licensed.
- For production, update authentication and session settings as needed.

## Troubleshooting

- If you encounter database errors, verify your connection string and that SQL Server is running.
- For Telerik UI issues, ensure the correct version is installed and licensed.

## License

This project is for demonstration purposes. See individual library licenses for details.

