using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_1
{
    public class BicycleRental
    {
        public BicycleRental()
        {
            Bicycle = new Bicycle();
            Customer = new Customer();
        }
        public Bicycle Bicycle { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentalStartTime { get; set; }
        public DateTime RentalEndTime { get; set; }

        public double RentalDurationHours
        {
            get => (RentalEndTime - RentalStartTime).TotalHours;
        }
    }
}
