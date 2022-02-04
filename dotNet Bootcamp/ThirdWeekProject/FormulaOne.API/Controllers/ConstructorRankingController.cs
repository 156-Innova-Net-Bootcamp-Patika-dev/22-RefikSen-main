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
    public class ConstructorRankingController : ControllerBase
    {
        private IConstructorRankingService _constructorRankingService;
                
        private readonly ILogger<ConstructorRankingController> _logger;

        private readonly IMapper _mapper;

        public ConstructorRankingController(ILogger<ConstructorRankingController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _constructorRankingService = new ConstructorRankingManager(new EfConstructorRankingDal());
        }


        [HttpGet]
        public List<ConstructorRanking> GetConstructorRankings()
        {
            return _constructorRankingService.GetAll();
        }

        [HttpPost]
        public IActionResult AddConstructorRanking([FromBody] ConstructorRankingDto constructorRankingDto)
        {
            var _constructorRanking = _constructorRankingService.GetAll().SingleOrDefault(x => x.TeamId == constructorRankingDto.TeamId);
            if (_constructorRanking == null)
            {
                _constructorRankingService.Add(_mapper.Map<ConstructorRanking>(constructorRankingDto));
                return Ok("Information : ConstructorRanking added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateConstructorRanking([FromBody] ConstructorRanking constructorRanking)
        {
            _constructorRankingService.Update(constructorRanking);
            return Ok("Information : ConstructorRanking updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConstructorRanking(int id)
        {
            ConstructorRanking constructorRanking = _constructorRankingService.Get(x => x.Id == id);
            _constructorRankingService.Delete(constructorRanking);
            return Ok();
        }
    }
}
