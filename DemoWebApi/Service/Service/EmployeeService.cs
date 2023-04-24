using DemoWebApi.Models;
using DemoWebApi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Service.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly ApiContext _context;
        public EmployeeService(ApiContext context)
        {
            _context = context;

        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _context.Employee.FindAsync(ID);
        }
        public async Task<Employee> AddEmployee(Employee objEmployee)
        {
            objEmployee.CreatedAt = DateTime.Now;
            _context.Employee.Add(objEmployee);
            await _context.SaveChangesAsync();
            return objEmployee;
        }

        public async Task<bool> DeleteEmployee(int ID)
        {
            bool result = false;
            var department = _context.Employee.Find(ID);
            if (department != null)
            {
                department.IsDeleated = true;
                _context.Update(department);
                await _context.SaveChangesAsync();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<List<EmployeeVM>> Filter(Filter filter)
        {
            List<EmployeeVM> employeesList = new List<EmployeeVM>();

            var query =
                (from e in _context.Employee
                 join d in _context.Department on e.DepartmentId equals d.DepartmentId
                 select new
                 {
                     e.EmployeeId,
                     e.FirstName,
                     e.LastName,
                     e.Email,
                     e.ContactNumber,
                     e.Salary,
                     e.Designation,
                     d.Name
                 }).ToList();

            foreach (var item in query)
            {
                EmployeeVM employee = new EmployeeVM();
                employee.EmployeeId = item.EmployeeId;
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.Email = item.Email;
                employee.ContactNumber = item.ContactNumber;
                employee.Salary = item.Salary;
                employee.Designation = item.Designation;
                employee.DepartmentName = item.Name;
                employeesList.Add(employee);
            }

            List<EmployeeVM> employeesFilter = new List<EmployeeVM>();

            if (!string.IsNullOrWhiteSpace(filter.DepartmentName))
            {
                employeesFilter = employeesList.Where(x => x.DepartmentName.Contains(filter.DepartmentName)).ToList();
            }

            List<EmployeeVM> employeesSearchFilter = new List<EmployeeVM>();
            if (employeesFilter.Any())
            {
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    employeesSearchFilter = employeesFilter.Where(x => x.FirstName.Contains(filter.Search) || x.LastName.Contains(filter.Search) || x.Email.Contains(filter.Search)).ToList();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    employeesSearchFilter = employeesList.Where(x => x.FirstName.Contains(filter.Search) || x.LastName.Contains(filter.Search) || x.Email.Contains(filter.Search)).ToList();
                }
            }

            List<EmployeeVM> employeesOrderFilter = new List<EmployeeVM>();
            if (employeesFilter.Any())
            {
                if (employeesSearchFilter.Any())
                {
                    if (filter.SortOrder == Sort.DESC)
                    {
                        switch (filter.Column)
                        {
                            case Column.department:
                                employeesOrderFilter = employeesSearchFilter.OrderByDescending(x => x.DepartmentName).ToList();
                                break;
                            case Column.salary:
                                employeesOrderFilter = employeesSearchFilter.OrderByDescending(x => x.Salary).ToList();
                                break;
                            case Column.designation:
                                employeesOrderFilter = employeesSearchFilter.OrderByDescending(x => x.Designation).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (filter.Column)
                        {
                            case Column.department:
                                employeesOrderFilter = employeesSearchFilter.OrderBy(x => x.DepartmentName).ToList();
                                break;
                            case Column.salary:
                                employeesOrderFilter = employeesSearchFilter.OrderBy(x => x.Salary).ToList();
                                break;
                            case Column.designation:
                                employeesOrderFilter = employeesSearchFilter.OrderBy(x => x.Designation).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    if (filter.SortOrder == Sort.DESC)
                    {
                        switch (filter.Column)
                        {
                            case Column.department:
                                employeesOrderFilter = employeesFilter.OrderByDescending(x => x.DepartmentName).ToList();
                                break;
                            case Column.salary:
                                employeesOrderFilter = employeesFilter.OrderByDescending(x => x.Salary).ToList();
                                break;
                            case Column.designation:
                                employeesOrderFilter = employeesFilter.OrderByDescending(x => x.Designation).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (filter.Column)
                        {
                            case Column.department:
                                employeesOrderFilter = employeesFilter.OrderBy(x => x.DepartmentName).ToList();
                                break;
                            case Column.salary:
                                employeesOrderFilter = employeesFilter.OrderBy(x => x.Salary).ToList();
                                break;
                            case Column.designation:
                                employeesOrderFilter = employeesFilter.OrderBy(x => x.Designation).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
            else
            {
                if (filter.SortOrder == Sort.DESC)
                {
                    switch (filter.Column)
                    {
                        case Column.department:
                            employeesOrderFilter = employeesList.OrderByDescending(x => x.DepartmentName).ToList();
                            break;
                        case Column.salary:
                            employeesOrderFilter = employeesList.OrderByDescending(x => x.Salary).ToList();
                            break;
                        case Column.designation:
                            employeesOrderFilter = employeesList.OrderByDescending(x => x.Designation).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (filter.Column)
                    {
                        case Column.department:
                            employeesOrderFilter = employeesList.OrderBy(x => x.DepartmentName).ToList();
                            break;
                        case Column.salary:
                            employeesOrderFilter = employeesList.OrderBy(x => x.Salary).ToList();
                            break;
                        case Column.designation:
                            employeesOrderFilter = employeesList.OrderBy(x => x.Designation).ToList();
                            break;
                        default:
                            break;
                    }
                }
            }

            return employeesOrderFilter;
        }
    }
}
