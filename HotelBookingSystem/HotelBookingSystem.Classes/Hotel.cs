namespace HotelBookingSystem.Classes;
public class Hotel
{
    public string Name { get; set; }

    public string City { get; set; }

    public string Adress { get; set; }

    public Hotel (string name, string city, string adress)
    {
        Name = name;
        City = city;
        Adress = adress;
    }
}
