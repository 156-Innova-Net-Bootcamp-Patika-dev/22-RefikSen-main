using AutoMapper;
using FormulaOne.Business.Abstract;
using FormulaOne.Business.Concrete;
using FormulaOne.DataAccess.Concrete.EntityFramework;
using FormulaOne.DataAccess.Models;
using FormulaOne.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace FormulaOne.API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
                
        private readonly ILogger<TeamController> _logger;

        private readonly IMapper _mapper;

        public TeamController(ILogger<TeamController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _teamService = new TeamManager(new EfTeamDal());
        }


        [HttpGet]
        public List<Team> GetTeams()
        {
            return _teamService.GetAll();
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] TeamDto teamDto)
        {
            var _team = _teamService.GetAll().SingleOrDefault(x => x.Name == teamDto.Name);
            if (_team == null)
            {
                _teamService.Add(_mapper.Map<Team>(teamDto));
                return Ok("Information : Team added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateTeam([FromBody] Team team)
        {
            _teamService.Update(team);
            return Ok("Information : Team updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            Team team = _teamService.Get(x => x.Id == id);
            _teamService.Delete(team);
            return Ok();
        }
    }
}
