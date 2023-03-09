# Day 2: 07-03-2023
1. Complete DepartmentAPI and EmployeeAPI for CRUD Operations
2. Make sure that Department and Employee ENtities are validated before Post and Put requests
3. While adding new Employee for a Dept, make sure that the capacity of the Departent is not already fulled with employees (Mandatory Today)
4. Create an API that will add a new Department and Multiple employees for the department in a single POST request
5. CReate a Search API that will perform following operations using a Single Search Method (Mandatory Today)
```` csharp
		pubic IActionResult Search(string ctiteria)
		{
			// USe Criteria to search
			// e.g. if 'Criteria' is EmpName="ABC", then return all Employees having name starts with ABC
			// If Criterial = DeptName=IT and EmpName="ABC", then retrn all employees from IT Department having name starts with ABC
			// If Criteria = "Group By DeptName", then return all Employees group by DeptNAme
				- HINT: USe Dictionay<Key, Value>
					- Key: is DeptName
					- Value: is EMployees for DeptName
		}

````
# Date 09-March-2023
(Note: USe EF COre to Manage Db Operations)
1. Create a Custom Middleware that will perform the following
	- Log Each Request into the Database by creating follwoing table in database
		- LogId: int Identity Key
		- RequestDate: Date
		- RequestPath : string
			- The Url Requested
		- RequestType: string
			- Get/Post/Put/Delete
2. Enhance the ErrorHandlerMiddleware class to Log the Exception in Database by creating Table witl COlumns as follows
	- ErrorLOgId: int identity
	- ErrorDateTime: DateTime
	- ErrorMessage: String
	- RequestPath: string
	- RequestType: string