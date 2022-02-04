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
    public class RaceResultController : ControllerBase
    {
        private IRaceResultService _raceResultService;
                
        private readonly ILogger<RaceResultController> _logger;

        private readonly IMapper _mapper;

        public RaceResultController(ILogger<RaceResultController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _raceResultService = new RaceResultManager(new EfRaceResultDal());
        }


        [HttpGet]
        public List<RaceResult> GetRaceResults()
        {
            return _raceResultService.GetAll();
        }

        [HttpPost]
        public IActionResult AddRaceResult([FromBody] RaceResultDto raceResultDto)
        {
            var _raceResult = _raceResultService.GetAll().SingleOrDefault(x => x.DriverId == raceResultDto.DriverId);
            if (_raceResult == null)
            {
                _raceResultService.Add(_mapper.Map<RaceResult>(raceResultDto));
                return Ok("Information : RaceResult added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateRaceResult([FromBody] RaceResult raceResult)
        {
            _raceResultService.Update(raceResult);
            return Ok("Information : RaceResult updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRaceResult(int id)
        {
            RaceResult raceResult = _raceResultService.Get(x => x.Id == id);
            _raceResultService.Delete(raceResult);
            return Ok();
        }
    }
}
