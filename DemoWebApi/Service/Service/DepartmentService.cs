using DemoWebApi.Models;
using DemoWebApi.Service.Interface;

namespace DemoWebApi.Service.Service
{
    public class DepartmentService:IDepartment
    {
        private readonly ApiContext _context;
        public DepartmentService(ApiContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartent(Department model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                model.IsDeleted = false;
                _context.Department.Add(model);
                await _context.SaveChangesAsync();
                return model;

            }
            catch 
            {

                throw;
            }
        }
    }
}
