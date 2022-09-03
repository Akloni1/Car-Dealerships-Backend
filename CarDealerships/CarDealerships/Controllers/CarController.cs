using CarDealerships.Models;
using CarDealerships.Services;
using CarDealerships.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CarDealerships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarServices _carServices;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarServices carServices, ILogger<CarController> logger)
        {
            _carServices = carServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostCar(InputCarViewModel inputModel)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var car = await _carServices.AddCar(inputModel);
            if (car != null)
            {
                _logger.LogInformation($"Автомобиль id которого {car.IdCar} добавился в салон id которого {car.IdCarDealership} "); ;
                return Ok(car);
            }
            _logger.LogError("Ошибка добавления автомобиля");
            return BadRequest();
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CarsInShowroomsViewModel>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<CarsInShowroomsViewModel>>> GetNumberOfCarsInShowrooms()
        {
            var res = await _carServices.GetNumberOfCarsInShowrooms();
            _logger.LogInformation("Произошел возврат автосалонов и какое количество автомобилей они имеют"); ;
            return Ok(res);
        }
    }
}
