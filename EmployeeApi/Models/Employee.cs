namespace EmployeeApi.Models
{
    // Store employee data inside Employee object
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string HireDate { get; set; } = string.Empty;
    }
}
