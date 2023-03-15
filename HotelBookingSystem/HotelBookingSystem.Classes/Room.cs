namespace HotelBookingSystem.Classes;
public class Room
{
    public string TypeOfRoom { get; set; }

    public int NumberOfRooms { get; set; }

    public int Cost { get; set; }

    public Hotel Placement { get; set; }

    public Room (string typeOfRoom, int numberOfRooms, int cost, Hotel placement)
    {
        TypeOfRoom = typeOfRoom;
        NumberOfRooms = numberOfRooms;
        Cost = cost;
        Placement = placement;
    }
}
