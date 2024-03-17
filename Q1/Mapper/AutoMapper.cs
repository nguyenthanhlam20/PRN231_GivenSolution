using AutoMapper;
using Q1.DTOs;
using Q1.Models;
//using Q1.DTOs;
//using Q1.Models;

namespace Q1.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Skill, SKillDTO>()
                .ForMember(dest => dest.numberOfEmployee, opt => opt.MapFrom(src => src.EmployeeSkills.Count));

            CreateMap<Skill, SKillDTO2>();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.DepartmentName));



            //CreateMap<Order , OrderDTO>()
            //    .ForMember(o => o.CustomerName, opt => opt.MapFrom(src => src.Customer!.CompanyName))
            //            .ForMember(o => o.EmployeeName, opt => opt.MapFrom(o => o.Employee!.FirstName + ' ' + o.Employee!.LastName))
            //            .ForMember(o => o.EmployeeDepartmentId, opt => opt.MapFrom(o => o.Employee!.DepartmentId))
            //            .ForMember(o => o.EmployeeDepartmentName, opt => opt.MapFrom(o => o.Employee!.Department!.DepartmentName));
            //CreateMap<Customer, DTOs.CustomerDTO>();
            //CreateMap<DTOs.CustomerDTO, Customer>();
        }

        private string GetProficiencyLevelsForSkill1(ICollection<EmployeeSkill> employeeSkills)
    {
        // Filter and concatenate proficiency levels for SkillId = 1 into a single string
        var proficiencyLevelsForSkill1 = employeeSkills
            .Where(es => es.SkillId == 1)
            .Select(es => es.ProficiencyLevel);
        return string.Join(", ", proficiencyLevelsForSkill1);
    }
    }
}
