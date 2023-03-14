namespace HeartbreakHotel;
public class Lodger
{
    public int Passport { get; set; }

    public string Name { get; set; }

    public DateOnly Birthday { get; set; }

    public Lodger (int passport, string name, DateOnly birthday)
    {
        Passport = passport;
        Name = name;
        Birthday = birthday;
    }
}
