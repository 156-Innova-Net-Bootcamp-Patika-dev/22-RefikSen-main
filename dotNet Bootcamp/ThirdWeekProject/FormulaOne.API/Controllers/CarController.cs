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
    public class CarController : ControllerBase
    {
        private ICarService _carService;
                
        private readonly ILogger<CarController> _logger;

        private readonly IMapper _mapper;

        public CarController(ILogger<CarController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _carService = new CarManager(new EfCarDal());
        }


        [HttpGet]
        public List<Car> GetCars()
        {
            return _carService.GetAll();
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] CarDto carDto)
        {
            var _car = _carService.GetAll().SingleOrDefault(x => x.Name == carDto.Name);
            if (_car == null)
            {
                _carService.Add(_mapper.Map<Car>(carDto));
                return Ok("Information : Car added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            _carService.Update(car);
            return Ok("Information : Car updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            Car car = _carService.Get(x => x.Id == id);
            _carService.Delete(car);
            return Ok();
        }
    }
}
