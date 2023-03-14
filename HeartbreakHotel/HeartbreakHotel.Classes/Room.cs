namespace HeartbreakHotel;
public class Room
{
    public string TypeOfRoom { get; set;  }
    
    public int NumberOfRooms { get; set; }

    public int Cost { get; set; }

    public Room (string typeOfRoom, int numberOfRooms, int cost)
    {
        TypeOfRoom = typeOfRoom;
        NumberOfRooms = numberOfRooms;
        Cost = cost;
    }
}
