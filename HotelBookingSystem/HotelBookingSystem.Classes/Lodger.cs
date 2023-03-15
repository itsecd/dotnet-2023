namespace HotelBookingSystem.Classes;
public class Lodger
{
    public int Passport { get; set; }

    public string Name { get; set; }

    public DateTime Birthdate { get; set; }

    public List<BookedRooms> Brooms { get; set; }

    public Lodger (int passport, string name, DateTime birthdate, List<BookedRooms> brooms)
    { 
        Passport = passport; 
        Name = name;
        Birthdate = birthdate;
        Brooms = brooms;
    }
}
