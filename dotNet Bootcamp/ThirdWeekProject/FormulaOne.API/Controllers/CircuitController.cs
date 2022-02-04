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
    public class CircuitController : ControllerBase
    {
        private ICircuitService _circuitService;
                
        private readonly ILogger<CircuitController> _logger;

        private readonly IMapper _mapper;

        public CircuitController(ILogger<CircuitController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _circuitService = new CircuitManager(new EfCircuitDal());
        }


        [HttpGet]
        public List<Circuit> GetCircuits()
        {
            return _circuitService.GetAll();
        }

        [HttpPost]
        public IActionResult AddCircuit([FromBody] CircuitDto circuitDto)
        {
            var _circuit = _circuitService.GetAll().SingleOrDefault(x => x.Name == circuitDto.Name);
            if (_circuit == null)
            {
                _circuitService.Add(_mapper.Map<Circuit>(circuitDto));
                return Ok("Information : Circuit added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateCircuit([FromBody] Circuit circuit)
        {
            _circuitService.Update(circuit);
            return Ok("Information : Circuit updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCircuit(int id)
        {
            Circuit circuit = _circuitService.Get(x => x.Id == id);
            _circuitService.Delete(circuit);
            return Ok();
        }
    }
}
