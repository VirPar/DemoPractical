# DemoPractical
Preferred technology for development: Asp.Net Core (3.1 or above framework), Entity framework, SQL Server database
Consider two entities:
1. Department
o DepartmentId
o Name
o CreatedAt
2. Employee
o EmployeeId
o FirstName
o LastName
o Email
o ContactNumber
o Salary
o Designation
o DepartmentId
o CreatedAt
Tasks:
1. Create Add Department API
2. Create Add Employee and Delete Employee API
3. Create one page to display all the employee details with department name (Authentication and Authorization required – (Must have to use API to get the data))
4. Apply filters to get employee by department name
5. Search employee by Name and email
6. Sort employee by department, salary, designation
Notes:
1. When delete employee it should be soft deleted
2. Use any Authentication method in Employee API to Authorize employee detail page
3. Necessary validations are required
4. API needs to test in Postman OR Swagger
5. Use entity framework repository pattern
6. Code first or Database first approach allowed
