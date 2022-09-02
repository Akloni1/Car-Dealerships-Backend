namespace CarDealerships.Models
{
    public class CarDealership
    {
        public CarDealership()
        {
            Cars = new HashSet<Car>();
        }
        public int IdCarDealership { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
