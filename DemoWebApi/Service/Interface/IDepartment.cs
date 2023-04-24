using DemoWebApi.Models;

namespace DemoWebApi.Service.Interface
{
    public interface IDepartment
    {
        Task<Department> AddDepartent(Department model);
    }
}
