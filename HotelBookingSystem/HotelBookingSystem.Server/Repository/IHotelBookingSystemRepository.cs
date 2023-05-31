using HotelBookingSystem.Model;

namespace HotelBookingSystem.Server.Repository;
public interface IHotelBookingSystemRepository
{
    List<BookedRooms> ListOfBookedRooms { get; }
    List<Hotel> ListOfHotels { get; }
    List<Lodger> ListOfLodgers { get; }
    List<Room> ListOfRooms { get; }
}