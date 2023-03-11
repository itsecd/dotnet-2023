namespace CarSharing
{
    /// <summary>
    /// describes a person who rented a car 
    /// </summary>
    public class Client
    {
        /// <summary>
        /// client's id
        /// </summary>
        public Guid Uid { get; set; } = Guid.Empty;

        /// <summary>
        /// client's passport number
        /// </summary>

        public string Passport { get; set; } = string.Empty;

        /// <summary>
        /// client's birthday date
        /// </summary>

        public DateTime BirthDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// client's fistname and lastname
        /// </summary>

        public string FirstName { set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;

        public Client() { }

        public Client(Guid uid, string passport, DateTime birthdate, string firstname, string lastname)
        {
            Uid = uid;
            Passport = passport;
            BirthDate = birthdate;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}