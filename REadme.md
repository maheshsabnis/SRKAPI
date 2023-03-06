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