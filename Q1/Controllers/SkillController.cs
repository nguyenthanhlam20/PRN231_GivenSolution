using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;


namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ODataController
    {
        private readonly Spring24B1_ScriptContext _dbContext;
        private readonly IMapper _mapper;
        public SkillController(Spring24B1_ScriptContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet("GetSkills")]
        public IActionResult GetSkills()
        {
            var list = _dbContext.Skills
                .Include(s => s.EmployeeSkills)
                .ToList();
            return Ok(_mapper.Map<List<SKillDTO>>(list));
        }

        [EnableQuery]
        [HttpGet("GetSkill/{SkillId}")]
        public IActionResult GetSkillByID(int SkillId)
        {
            Skill? skill = _dbContext.Skills.SingleOrDefault(s => s.SkillId == SkillId);
            if (skill == null)
            {
                return NotFound();
            }
            var ems = (from emp in _dbContext.Employees
                       join de in _dbContext.Departments on emp.EmployeeId equals de.ManagerId
                       join eskil in _dbContext.EmployeeSkills on emp.EmployeeId equals eskil.EmployeeId
                       join ski in _dbContext.Skills on eskil.SkillId equals ski.SkillId
                       where ski.SkillId == SkillId
                       select new
                       {
                           employeeId = emp.EmployeeId,
                           employeeName = emp.Name,
                           department = de.DepartmentName,
                           proficiencyLevel = eskil.ProficiencyLevel,
                           acquiredDate = eskil.AcquiredDate,
                       }).ToList();
            return Ok(new
            {
                skillId = skill.SkillId,
                skillName = skill.SkillName,
                description = skill.Description,
                employees = ems,
            });
        }
    }
}
