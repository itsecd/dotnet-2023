namespace HeartbreakHotel;
public class Hotel
{
    public string Name { get; set; }

    public string City { get; set; }

    public string Adress { get; set; }

    public Hotel (string hotelName, string hotelCity, string hotelAdress)
    {
        Name = hotelName;
        City = hotelCity;
        Adress = hotelAdress;
    }
}
