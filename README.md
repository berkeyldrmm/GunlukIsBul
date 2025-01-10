# GunlukIsBul Project

This project is a management and job listing platform developed for companies that find daily jobs. Admins can manage job postings and categories via the admin panel, while the homepage displays current and upcoming job postings.

## Project Features

### General Features
- **Admin Panel**: Admin users can add, update, and delete job postings.
- **Category Management**: Categories can be created and edited while adding job postings.
- **Homepage**: Displays current and upcoming job postings.

### Technologies
- **Backend**: ASP.NET Core
- **Database**: SQLite (with Entity Framework Core)
- **Validation**: FluentValidation
- **Object Mapping**: AutoMapper
- **Authentication**: Cookie Authentication

## Project Setup

### Requirements
- .NET 6.0 or later
- Visual Studio 2022 or a similar IDE

### Installation Steps
1. **Clone the Project:**
   ```bash
   git clone https://github.com/username/GunlukIsBul.git
   cd GunlukIsBul
   ```
2. **Install Dependencies:**
   If you're using Visual Studio, dependencies will be installed automatically when you open the project.

3. **Prepare the Database:**
   The database connection is specified in the `appsettings.json` file. The project uses SQLite, so no additional setup is needed.

4. **Run the Project:**
   ```bash
   dotnet run
   ```

5. **Access the Application in Your Browser:**
   ```
   http://localhost:5000
   ```

## Project Structure

```
GunlukIsBul/
├── GunlukIsBul.sln           # Solution File
├── GunlukIsBul/             # Main Project Folder
│   ├── Program.cs          # Entry Point
│   ├── appsettings.json    # Configuration File
│   ├── DataAccessLayer/    # Database Operations
│   ├── BusinessLayer/      # Business Logic
│   ├── Controllers/        # API and MVC Controllers
│   └── Views/              # Razor Pages
```

## Usage

1. **Admin Login:** Admin users can perform job posting and category operations.
2. **Homepage:** Users can view current and upcoming job postings.

## Contributing

If you would like to contribute to the project, create a fork and submit your changes via a pull request.
