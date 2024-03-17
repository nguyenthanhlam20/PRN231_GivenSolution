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
    public class EmployeeController : ODataController
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
        public IActionResult GetAllOrder( int EmployeeId)
        {
            return Ok();
        }

    }
}
