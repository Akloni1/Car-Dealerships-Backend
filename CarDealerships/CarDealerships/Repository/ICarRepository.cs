using CarDealerships.Models;
using CarDealerships.ViewModels;

namespace CarDealerships.Repository
{
    public interface ICarRepository
    {
        Task<Car> AddCar(Car car);
        Task<List<CountCarGroupViewModel>> GetCountCarsGroupByCarDealerships(InputCarViewModel carModel);

        Task<List<CarsInShowroomsViewModel>> GetNumberOfCarsInShowrooms();
        Task<int> GetCountCarByShowroom(int id);


    }
}
