using CarDealerships.ViewModels;

namespace CarDealerships.Services
{
    public interface ICarServices
    {
        Task<List<CarsInShowroomsViewModel>> GetNumberOfCarsInShowrooms();
        Task<CarViewModel> AddCar(InputCarViewModel carModel);
    }
}
