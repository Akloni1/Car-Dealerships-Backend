using AutoMapper.Execution;
using CarDealerships.Data;
using CarDealerships.Models;
using CarDealerships.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;


namespace CarDealerships.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealershipsContext _context;
        public CarRepository(CarDealershipsContext context)
        {
            _context = context;
        }
        public async Task<Car> AddCar(Car inputModel)
        {
            var car = _context.Add(inputModel).Entity;
            await _context.SaveChangesAsync();
            return car;

        }

        public async Task<List<CountCarGroupViewModel>> GetCountCarsGroupByCarDealerships(InputCarViewModel carModel)
        {
            var result = (from cd in _context.CarDealerships
                          join c in (
                          from c1 in _context.Cars
                          where c1.Stamp == carModel.Stamp
                          where c1.Color == carModel.Color
                          select new { c1.IdCar, c1.Stamp, c1.Color, c1.IdCarDealership }
                          ) on cd.IdCarDealership equals c.IdCarDealership into ps
                          from c in ps.DefaultIfEmpty()
                          where c.Stamp == carModel.Stamp || c.Stamp == null
                          where c.Color == carModel.Color || c.Color == null
                          group cd by new { cd.IdCarDealership, c.Color } into g
                          select new CountCarGroupViewModel { IdCarDealership = g.Key.IdCarDealership, Count = g.Key.Color == null ? 0 : g.Count() } into res
                          orderby res.Count
                          select res).Take(2).ToList();

            return result;
        }
        public async Task<List<CarsInShowroomsViewModel>> GetNumberOfCarsInShowrooms()
        {
            var result = (from cd in _context.CarDealerships
                          join c in _context.Cars
                          on cd.IdCarDealership equals c.IdCarDealership
                          group cd by new { cd.IdCarDealership, cd.Name, c.Stamp, c.Color } into g
                          select new CarsInShowroomsViewModel { NameCarDealership = g.Key.Name, Stamp = g.Key.Stamp, Color = g.Key.Color, Count = g.Count() }).ToList();
            return result;
        }

        public async Task<int> GetCountCarByShowroom(int id)
        {
            return await _context.Cars.CountAsync(c => c.IdCarDealership == id);
        }


    }
}
