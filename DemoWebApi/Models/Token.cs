namespace DemoWebApi.Models
{
    public class Token
    {
    }

    public class JWTTokenResponse
    {
        public string? Token
        {
            get;
            set;
        }
    }

    public class Login
    {
        public string? Email
        {
            get;
            set;
        }
        public string? Password
        {
            get;
            set;
        }
    }

    public class Filter
    {
        public string? DepartmentName { get; set; }
        public string? Search { get; set; }
        public Sort? SortOrder { get; set; }

        public Column? Column { get; set; }
    }

    public enum Sort
    {
        ASD, DESC
    }

    public enum Column
    {
        department, salary, designation
    }

    public partial class EmployeeVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public string DepartmentName { get; set; }
    }
}
