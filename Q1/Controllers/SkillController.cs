using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult GetAllOrder()
        {
            return Ok();
        }

        [EnableQuery]
        [HttpGet("GetSkill/{SkillId}")]
        public IActionResult GetSkillByID(int SkillId)
        {
            return Ok();
        }



    }
}
