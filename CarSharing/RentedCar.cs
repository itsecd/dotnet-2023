namespace CarSharing
{
    /// <summary>
    /// this class describes car that've been rented and was or was not returned, also this class conncts other three classes
    /// </summary>
    public class RentedCar
    {
        /// <summary>
        /// connections to other classes, represent a client, who rented a car, a point, where they rented a car, and the rented car itself
        /// </summary>
        public Client Client { get; set; } = new();
        public RentalPoint Point { get; set; } = new();
        public Car Car { get; set; } = new();

        /// <summary>
        /// id of rented car
        /// </summary>
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// date and time when client rented a car
        /// </summary>
        public DateTime TimeOfRent { get; set; } = DateTime.MinValue;

        /// <summary>
        /// period of time when the client can use a rented car 
        /// </summary>
        public uint RentPeriod { get; set; } = 0;

        /// <summary>
        /// a day when car must be returned to the rental point
        /// </summary>
        public DateTime TimeOfReturn { get => TimeOfRent.AddDays(RentPeriod); }
        public RentedCar() { }

        public RentedCar(Guid id, Client client, RentalPoint point, CarList car, DateTime timeOfRent, uint rentPeriod)
        {
            Id = id;
            Client = client;
            Point = point;
            Car = car;
            TimeOfRent = timeOfRent;
            RentPeriod = rentPeriod;
        }
    }
}
