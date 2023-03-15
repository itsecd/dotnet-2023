namespace HotelBookingSystem.Classes;
public class Lodger
{
    public int Passport { get; set; }

    public string Name { get; set; }

    public DateTime Birthdate { get; set; }

    public List<BookedRooms> Brooms { get; set; }

    public Lodger (List<BookedRooms> brooms, int passport, string name, DateTime birthdate)
    { 
        Passport = passport; 
        Name = name;
        Birthdate = birthdate;
        Brooms = brooms;
    }
}
