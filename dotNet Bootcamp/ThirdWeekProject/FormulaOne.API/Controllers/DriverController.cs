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
    public class DriverController : ControllerBase
    {
        private IDriverService _driverService;
                
        private readonly ILogger<DriverController> _logger;

        private readonly IMapper _mapper;

        public DriverController(ILogger<DriverController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _driverService = new DriverManager(new EfDriverDal());
        }


        [HttpGet]
        public List<Driver> GetDrivers()
        {
            return _driverService.GetAll();
        }

        [HttpPost]
        public IActionResult AddDriver([FromBody] DriverDto driverDto)
        {
            var _driverName = _driverService.GetAll().SingleOrDefault(x => x.FirstName == driverDto.FirstName);
            var _driverSurname = _driverService.GetAll().SingleOrDefault(x => x.LastName == driverDto.LastName);
            var _driverAge = _driverService.GetAll().SingleOrDefault(x => x.Age == driverDto.Age);
            if (_driverName == null && _driverSurname == null && _driverAge == null)
            {
                _driverService.Add(_mapper.Map<Driver>(driverDto));
                return Ok("Information : Driver added!");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateDriver([FromBody] Driver driver)
        {
            _driverService.Update(driver);
            return Ok("Information : Driver updated!");            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            Driver driver = _driverService.Get(x => x.Id == id);
            _driverService.Delete(driver);
            return Ok();
        }
    }
}
