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
    public class DriverRankingController : ControllerBase
    {
        private IDriverRankingService _driverRankingService;
                
        private readonly ILogger<DriverRankingController> _logger;

        private readonly IMapper _mapper;

        public DriverRankingController(ILogger<DriverRankingController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _driverRankingService = new DriverRankingManager(new EfDriverRankingDal());
        }


        [HttpGet]
        public List<DriverRanking> GetDriverRankings()
        {
            return _driverRankingService.GetAll();
        }

        [HttpPost]
        public IActionResult AddDriverRanking([FromBody] DriverRankingDto driverRankingDto)
        {
            var _driverRanking = _driverRankingService.GetAll().SingleOrDefault(x => x.DriverId == driverRankingDto.DriverId);
            if (_driverRanking == null)
            {
                _driverRankingService.Add(_mapper.Map<DriverRanking>(driverRankingDto));
                return Ok("Information : DriverRanking added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateDriverRanking([FromBody] DriverRanking driverRanking)
        {
            _driverRankingService.Update(driverRanking);
            return Ok("Information : DriverRanking updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriverRanking(int id)
        {
            DriverRanking driverRanking = _driverRankingService.Get(x => x.Id == id);
            _driverRankingService.Delete(driverRanking);
            return Ok();
        }
    }
}
