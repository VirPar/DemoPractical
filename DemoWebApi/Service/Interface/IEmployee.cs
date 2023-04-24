using DemoWebApi.Models;

namespace DemoWebApi.Service.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> AddEmployee(Employee model);
        Task<List<EmployeeVM>> Filter(Filter filter);
        Task<bool> DeleteEmployee(int ID);
    }
}
