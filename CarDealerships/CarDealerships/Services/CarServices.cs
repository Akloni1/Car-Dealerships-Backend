using AutoMapper;
using CarDealerships.Models;
using CarDealerships.Repository;
using CarDealerships.ViewModels;
using System.Diagnostics.Metrics;


namespace CarDealerships.Services
{
    public class CarServices : ICarServices
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private Random _rand;
        public CarServices(IMapper mapper, ICarRepository carRepository)
        {

            _mapper = mapper;
            _carRepository = carRepository;
            _rand = new Random();
        }
        public async Task<CarViewModel> AddCar(InputCarViewModel carModel)
        {
            
            var randNum = _rand.Next(1, 1001);
            var CountCarsGroupByCarDealerships = await _carRepository.GetCountCarsGroupByCarDealerships(carModel);
            var difference = Math.Abs(CountCarsGroupByCarDealerships[0].Count - CountCarsGroupByCarDealerships[1].Count);
            Car carOut;
            Car carInput = _mapper.Map<Car>(carModel);

            if (difference == 0)
            {
                if (randNum <= 500)
                {
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[0].IdCarDealership;
                }
                else
                {
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[1].IdCarDealership;                 
                }
            }
            else if (difference == 1)
            {
                if (randNum <= 666)
                {                   
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[0].IdCarDealership;
                }
                else
                {                  
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[1].IdCarDealership;                   
                }
            }
            else if (difference == 2)
            {
                if (randNum <= 800)
                {                   
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[0].IdCarDealership;                
                }
                else
                {                  
                    carInput.IdCarDealership = CountCarsGroupByCarDealerships[1].IdCarDealership;                
                }
            }
            else
            {                
                carInput.IdCarDealership = CountCarsGroupByCarDealerships[0].IdCarDealership;             
            }
            var countCar = await _carRepository.GetCountCarByShowroom(carInput.IdCarDealership);
            if (!(countCar >= 0 && countCar < 100))
            {
                throw new Exception($"Место_для_автомобилей_в_автосолоне_id={carInput.IdCarDealership}_закончилось");
            }
            carOut = await _carRepository.AddCar(carInput);
            return _mapper.Map<CarViewModel>(carOut);

        }

        public async Task<List<CarsInShowroomsViewModel>> GetNumberOfCarsInShowrooms()
        {
           
            return await _carRepository.GetNumberOfCarsInShowrooms();
        }
    }
}
