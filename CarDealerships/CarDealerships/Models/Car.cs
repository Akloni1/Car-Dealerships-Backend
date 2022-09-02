using System;

namespace CarDealerships.Models
{
    public class Car
    {
        public int IdCar { get; set; }
        public string Stamp { get; set; }
        public string Color { get; set; }
        public int IdCarDealership { get; set; }
        public virtual CarDealership CarDealership { get; set; }
    }
}
