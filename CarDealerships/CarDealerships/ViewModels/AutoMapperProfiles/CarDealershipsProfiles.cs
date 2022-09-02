using AutoMapper;
using CarDealerships.Models;

namespace CarDealerships.ViewModels.AutoMapperProfiles
{
    public class CarDealershipsProfiles : Profile
    {
        public CarDealershipsProfiles()
        {
            CreateMap<Car, InputCarViewModel>().ReverseMap();
            CreateMap<Car, CarViewModel>();
        }
    }
}
