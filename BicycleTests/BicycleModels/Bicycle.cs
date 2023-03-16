
using BicycleTests.BicycleModels;

namespace BicycleTests
{
    internal class Bicycle
    {
        public Bicycle()
        {
            Type = new BicycleType();
        }
        public int SerialNumber { get; set; }
        public BicycleType Type { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
    }
}
