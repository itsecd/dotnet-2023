namespace CarSharing
{
    /// <summary>
    /// this class describes all cars which can be rented in rent poits
    /// </summary>
    public class Car
    {
        /// <summary>
        /// model of the car
        /// </summary>
        public string Model { get; set; } = string.Empty;
        /// <summary>
        /// colour of the car
        /// </summary>
        public string Colour { get; set; } = string.Empty;

        /// <summary>
        /// number of the car
        /// </summary>

        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// id of the car
        /// </summary>
        public Guid CarId { get; set; } = Guid.Empty;

        public Car() { }

        public Car(Guid carId, string model, string colour, string number)
        {
            CarId = carId;
            Model = model;
            Colour = colour;
            Number = number;
        }
    }
}
