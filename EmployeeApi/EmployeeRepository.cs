using AutoMapper;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository() 
        {
            using (var context = new ApiContext()) 
            {
                // Check if dbSet is empty before adding initial values (prevents these objects from being added to the db after every request)
                var set = context.Set<Employee>();
                if (set.Any() == false)
                {
                    // Create list of employee information, then insert list into DbSet
                    var employees = new List<Employee>()
                    {
                        new Employee
                        {
                            Id = 1,
                            LastName = "Jackson",
                            FirstName = "Alberta",
                            Department = "Finance",
                            HireDate = "6/5/2007"
                        },
                        new Employee
                        {
                            Id = 2,
                            LastName = "Bennett",
                            FirstName = "Alicia",
                            Department = "Human Resources",
                            HireDate = "4/15/2001"
                        },
                        new Employee
                        {
                            Id = 3,
                            LastName = "Avent",
                            FirstName = "Donna",
                            Department = "Revenue",
                            HireDate = "4/20/2009"
                        },
                        new Employee
                        {
                            Id = 4,
                            LastName = "Holder",
                            FirstName = "Duane",
                            Department = "Human Services",
                            HireDate = "8/15/2020"
                        }
                    };
                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }
            }
        }
        // Returns list of all employees
        public List<Employee> GetAllEmployees()
        {
            using (var context = new ApiContext())
            {
                var list = context.Employees.ToList();
                return list;
            }
        }
        // Gets specific employee from id
        public List<Employee> GetEmployee(int id)
        {
            using (var context = new ApiContext()) 
            {
                var list = context.Employees.Where(employee => employee.Id == id).ToList();
                return list;
            }
        }
        // Adds new employee
        public void PostEmployee(Employee employee)
        {
            using (var context = new ApiContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
    }
}
