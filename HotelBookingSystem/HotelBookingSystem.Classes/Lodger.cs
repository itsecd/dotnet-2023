namespace HotelBookingSystem.Classes;
public class Lodger
{
    public int Passport { get; set; }

    public string Name { get; set; }

    public DateTime Birthdate { get; set; }

    public Lodger (int passport, string name, DateTime birthdate)
    { 
        Passport = passport; 
        Name = name;
        Birthdate = birthdate;
    }
}
