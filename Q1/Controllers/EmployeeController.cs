using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Q1.Models;
//using Q1.DTOs;
//using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Spring24B1_ScriptContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeController(Spring24B1_ScriptContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpDelete("Delete/{EmployeeId}")]
        public IActionResult DeleteEmployeeById(int EmployeeId)
        {
            try
            {
                Employee? employee = _dbContext.Employees.SingleOrDefault(e => e.EmployeeId == EmployeeId);

                if (employee == null)
                {
                    return NotFound($"No employee with id {EmployeeId}");
                }

                employee.EmployeeSkills = _dbContext.EmployeeSkills.Where(x => x.EmployeeId == EmployeeId).ToList();
                employee.Departments = (from emp in _dbContext.Employees
                                        join dept in _dbContext.Departments on emp.DepartmentId equals dept.ManagerId
                                        where emp.EmployeeId == EmployeeId
                                        select dept).ToList();

                employee.EmployeeProjects = _dbContext.EmployeeProjects.Where(e => e.EmployeeId == EmployeeId).ToList();

                int numberOfSkills = employee.EmployeeSkills.Count;
                int numberOfDepartments = employee.Departments.Count;
                int numberOfProjects = employee.EmployeeProjects.Count;

                _dbContext.RemoveRange(employee.EmployeeSkills);
                _dbContext.RemoveRange(employee.EmployeeProjects);
                _dbContext.Remove(employee);


                if (_dbContext.SaveChanges() > 0)
                {
                    return Ok(new
                    {
                        numberOfProjects,
                        numberOfSkills,
                        numberOfDepartments
                    });
                }
                return BadRequest("Cannot delete employee");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
