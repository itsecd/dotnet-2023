
namespace BicycleTests.BicycleModels
{
    internal class Price
    {
        public Price()
        {
            Type = new BicycleType();
        }
        public BicycleType Type { get; set; }
        public decimal RentalPricePerHour { get; set; }
    }
}
