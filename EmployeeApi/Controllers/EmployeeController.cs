using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using AutoMapper;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // /api/Employee Returns employee list sorted by LastName then FirstName
        [HttpGet]
        public ActionResult<List<Employee>> Get() 
        {
            var list = _employeeRepository.GetAllEmployees();
            var mappedList = list.Select(employee => _mapper.Map<EmployeeDto>(employee));
            
            return Ok(mappedList.OrderBy(employee => employee.LastName).ThenBy(employee => employee.FirstName));
        }
        
        // /api/Employee/{id} Returns full employee resource from id
        [HttpGet("{id}")]
        public ActionResult<List<Employee>> Get(int id)
        {
            return Ok(_employeeRepository.GetEmployee(id));
        }

        // /api/Employee/post Creates a new employee, returns confirmation message
        [HttpPost("post")]
        public string Post(Employee employee)
        {
            _employeeRepository.PostEmployee(employee);
            return "account created for: " + employee.FirstName + " " + employee.LastName + " (ID: " + employee.Id + ")";
        }
    }
}
