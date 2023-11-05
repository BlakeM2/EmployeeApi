using AutoMapper;

namespace EmployeeApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
