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
    public class TeamChiefController : ControllerBase
    {
        private ITeamChiefService _teamChiefService;
                
        private readonly ILogger<TeamChiefController> _logger;

        private readonly IMapper _mapper;

        public TeamChiefController(ILogger<TeamChiefController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _teamChiefService = new TeamChiefManager(new EfTeamChiefDal());
        }


        [HttpGet]
        public List<TeamChief> GetTeamChiefs()
        {
            return _teamChiefService.GetAll();
        }

        [HttpPost]
        public IActionResult AddTeamChief([FromBody] TeamChiefDto teamChiefDto)
        {
            var _teamChiefName = _teamChiefService.GetAll().SingleOrDefault(x => x.FirstName == teamChiefDto.FirstName);
            var _teamChiefSurname = _teamChiefService.GetAll().SingleOrDefault(x => x.LastName == teamChiefDto.LastName);
            var _teamChiefAge = _teamChiefService.GetAll().SingleOrDefault(x => x.Age == teamChiefDto.Age);

            if (_teamChiefName == null && _teamChiefSurname == null && _teamChiefAge == null)
            {
                _teamChiefService.Add(_mapper.Map<TeamChief>(teamChiefDto));
                return Ok("Information : TeamChief added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateTeamChief([FromBody] TeamChief teamChief)
        {
            _teamChiefService.Update(teamChief);
            return Ok("Information : TeamChief updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeamChief(int id)
        {
            TeamChief teamChief = _teamChiefService.Get(x => x.Id == id);
            _teamChiefService.Delete(teamChief);
            return Ok();
        }
    }
}
