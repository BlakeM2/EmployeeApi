using EmployeeApi.Models;

namespace EmployeeApi
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public List<Employee> GetEmployee(int id);
        public void PostEmployee(Employee employee);
    }
}
