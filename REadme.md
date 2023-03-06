# Interfaces

- Class can implement interface using following
	- Implicit INterface implementation
		- Although methods are declared in interface, the class own it and methods are accessed using Class INstance as well as interace reerence
	- Explicit Interace implememtation
		- Methods are implemenetd in class using INterface reference
		- Methods can be invoked using either of the following
			- USing Interface reference
			- TypeCasting the class instance using interface reference 

# ASP.NET Core Apps
- Data Access
	- EntityFramework Core (EF Core)
		- Object Relational Mapping (ORM)
		- Map the CLR Class (.NET Class) with Database Table
			- Public Property of the class maps with Table COlumn
		- Prvides Methods for
			- Database Connection
			- CRUD OPerations
			- Accessing Stored Procedures
			- Handling Transactions
		- Approaches
			- Database First
				- Generate .NET Models (aka Entities) from Database and its tables
				- USed in case the Database is Production Ready (No changes are needed in Database)
			- Code-First
				- Create .NET Entity Classes
				- Generate database from Entity Classes
				- USe this when application is developed from scratch
	- EF COre Object Model
		- DbContext
			- Base class for EF COre
				- Establish Connectio with database
				- Perform DB Transactions
					- SaveChanges()
					- SaveChangesAsync()
				- Map the CLR class with Database Table using 
```` csharp
DbSet<T>
````

```` csharp		
		- DbSet<T>
````			

			- Maps CLR class aka ENtity class with DbTable
				- T is the class that maps with Db Table named T
			- Manages CRUD OPerations
				- DbSet is Cursor that managed Operations in Memory
- Pseduo
		- Consider  'ctx' is an instance of DbContext
		- ENtity class is Employee, so DbSet<Employee> is 'Employees' 

		- REad all Employees
			- var emps = ctx.Employees.ToList();
			- var emps = await ctx.Employees.ToListAsync();
				- We need 'Microsoft.EntitFrameworkCore' package to be used
		- REad Record based on Priamry Key	
			- var emp = ctx.Employees.Find(PRIMARY-KEY-VALUE);
			- var emp = await ctx.Employees.FindAsync(PRIMARY-KEY-VALUE);
		- TO Add a ne Record
			- CReate an Instance of Entity Class
				- var emp = new Employee();
			- Set Its property values 
				- emp.EmpNo=101; emp.EmpName="Falana";....
			- Add this object in DbSet
				- ctx.Employees.Add(emp); 
				- ctx.Employees.AddAsync(emp);
			- Commit Transactions
				- ctx.SaveChanges();
				- ctx.SaveChangesAsync();
		- Adding Multiple Record
			- ctx.Employees.AddRanges(employees Array);
			- ctx.Employees.AddRageAsync(emloyees Array)
			- Commit Transaction
		- TO Update Record
			- Search record Based on Primary Key
			- Update Its property values
			- Commit Transaction
		- To Delete REcord
			- Search Record based on Primary Key
			- ctx.Employees.Remove(THE-SEARCHED-RECORD)
			- Commit TRansaction
	- Packages
		- Microsoft.EntityFrameworkore
		- Microsoft.EntityFrameworkore.SqlServer
		- Microsoft.EntityFrameworkore.Relational
		- Microsoft.EntityFrameworkore.Design
		- Microsoft.EntityFrameworkore.Tools
	- Using Visual STudio
		- Right-Click on Project --- MAnge NuGet PAckages --- Search for Pckage --- Install button
	- Using CLI
		- Open the Command Prompt / POwerShell WIndow / Terminal (Linux/Mac)
		- Navigato to the Project (Parent of 'bin' folder)
		- Run the Following Command
			- dotnet add package [PACKAGE-NAME] -v [VERSION-NUMBER]

	- Generating Entityies from Database
		- INstall EF CLI Tool
			- dotnet tool install --global dotnet-ef
			- Restart the Terminal WIndow
		- dotnet ef database scaffold "CONNECTION_STRING" Microsoft.EntityFrameworkCore.SqlServer -o Models

	- Using Code-First
		- Generate Migrations, thsi will generate C# Scripts to CReate Table
		- Create ENtity Classes
		- Create a Class Derived from 'DbContext' class
			-  Define DbSet proeprtes for each entity class
```` csharp
	public DbSet<Employee> Employees {get;set;}
````
			- dotnet ef migrations add [MIGRATION-NAME] -c [PRJECT-NAMESPACE.DBCONTEXT-CLASS-NAME]	
		- Update this migration to generate database and tables
			- dotnet ef database upate -c [PRJECT-NAMESPACE.DBCONTEXT-CLASS-NAME]	

- API Development
- Security

```` sql
USE [master]
GO

/****** Object:  Database [Company]    Script Date: 3/6/2023 4:10:48 PM ******/
CREATE DATABASE [Company]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Company_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Company] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Company] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Company] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Company] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Company] SET ARITHABORT OFF 
GO

ALTER DATABASE [Company] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Company] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Company] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Company] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Company] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Company] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Company] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Company] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Company] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Company] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Company] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Company] SET RECOVERY FULL 
GO

ALTER DATABASE [Company] SET  MULTI_USER 
GO

ALTER DATABASE [Company] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Company] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Company] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Company] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Company] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Company] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Company] SET  READ_WRITE 
GO



USE [Company]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 3/6/2023 4:11:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[DeptNo] [int] NOT NULL,
	[DeptName] [varchar](100) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Location] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Company]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 3/6/2023 4:12:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NOT NULL,
	[EmpName] [varchar](200) NOT NULL,
	[Designation] [varchar](200) NOT NULL,
	[Salary] [int] NOT NULL,
	[DeptNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DeptNo])
REFERENCES [dbo].[Department] ([DeptNo])
GO




````
