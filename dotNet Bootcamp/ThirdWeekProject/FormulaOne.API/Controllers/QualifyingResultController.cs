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
    public class QualifyingResultController : ControllerBase
    {
        private IQualifyingResultService _qualifyingResultService;
                
        private readonly ILogger<QualifyingResultController> _logger;

        private readonly IMapper _mapper;

        public QualifyingResultController(ILogger<QualifyingResultController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _qualifyingResultService = new QualifyingResultManager(new EfQualifyingResultDal());
        }


        [HttpGet]
        public List<QualifyingResult> GetQualifyingResults()
        {
            return _qualifyingResultService.GetAll();
        }

        [HttpPost]
        public IActionResult AddQualifyingResult([FromBody] QualifyingResultDto qualifyingResultDto)
        {
            var _qualifyingResult = _qualifyingResultService.GetAll().SingleOrDefault(x => x.DriverId == qualifyingResultDto.DriverId);
            if (_qualifyingResult == null)
            {
                _qualifyingResultService.Add(_mapper.Map<QualifyingResult>(qualifyingResultDto));
                return Ok("Information : QualifyingResult added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateQualifyingResult([FromBody] QualifyingResult qualifyingResult)
        {
            _qualifyingResultService.Update(qualifyingResult);
            return Ok("Information : QualifyingResult updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQualifyingResult(int id)
        {
            QualifyingResult qualifyingResult = _qualifyingResultService.Get(x => x.Id == id);
            _qualifyingResultService.Delete(qualifyingResult);
            return Ok();
        }
    }
}
