# netdemo

Technologies:
a. Visual Studio 2017 Community
b. ASP.Net Core 2.2.0
c. Entity Framework Core
d. MVC
e. Swagger UI
f. Postman

1. Create a Project named Models (a Class Library project).
	a. Person Class (Id, FirstName, LastName, Address, EmailAddress, Age, SecurityToken, IsActive)
	b. Training Class (Id, Name, Description, Location, PersonId, IsActive)
	c. DemoContext Class (DBContext) - DBSet<Person>, DbSet<Training>, ModelCreating
		Direction: Point the Default Project: Models, In Package Manager Console, type:
		c1. Add-Migration Initial
		c2. Update-Database
2. Create a Project named ViewModels (a Class Library project).
	a. PersonViewModel, PersonCreateViewModel, PersonUpdateViewModel
	b. TrainingViewModel, TrainingCreateViewModel, TrainingUpdateViewModel
3. Create a Project named Interfaces (a Class Library project)
	a. Project Dependencies (Models, ViewModels)
	b. IRepository
	c. Contract Folder
		c1. IPersonRepository
		c2. IPersonService
		c3. ITrainingRepository
		c4. ITrainingService
4. Create a Project named Repositories (a Class Library project) - (Data Access Layer) using Repository Pattern - structural pattern, instead of SQL Commands.
	a. Project Dependencies (Models, Interfaces)
	b. DbInitializer Class
	c. Repository Class
	d. Impl Folder 
		d1. PersonRepository: must implement IPersonRepository
		d2. TrainingRepository: must implement ITrainingRepository
5. Create a Project named Services (a Class Library project) (Business Logic Layer).
	a. Project Dependencies (Models, Interfaces)
	b. PersonService: must implement IPersonService
	c. TrainingService: must implement ITrainingService
	d. AuthenticationService: CreateToken, GetToken
6. Create a Project named WebAPI (a Web API project) - (Application/Integration Layer)
	a. Project Dependencies (Interfaces, Models, Repositories, Services, ViewModels)
	b. PersonController (CRUD)
		b1. Create (HttpPost) 
			url : api/person/create
		b2. GetAll (HttpGet) 
			url : api/person/getall
		b3. Get (HttpGet) 
			url : api/person/get/{id}
		b4. Update (HttpPut) 
			url : api/person/update
		b5. Delete (HttpDelete) 
			url : api/person/delete/{id}
	c. TrainingController (CRUD)
		c1. Create (HttpPost) 
			url : api/training/create
		c2. GetAll (HttpGet) 
			url : api/training/getall
		c3. Get (HttpGet) 
			url : api/training/get/{id}
		c4. Update (HttpPut) 
			url : api/training/update
		c5. Delete (HttpDelete)
			url : api/training/delete/{id}
	d. appsettings.json
	e. StartUp Class
	f. Swagger UI
		f1. In Package Manager Console, type: Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc2
		f2. Docs: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio
	g. Test the API using Postman
		g1. headers => content-type: application/json
7. Create an ASP.Net MVC Project - (Presentation Layer)
	a. Razor View (Template Engine)
	b. Ajax Calls