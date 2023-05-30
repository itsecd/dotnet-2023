using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;

namespace HotelBookingSystem.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelGetDto>();
        CreateMap<HotelPostDto, Hotel>();

        CreateMap<Room, RoomGetDto>();
        CreateMap<RoomPostDto, Room>();

        CreateMap<Lodger, LodgerGetDto>();
        CreateMap<LodgerPostDto, Lodger>();

        CreateMap<BookedRooms, BookedRoomsGetDto>();
        CreateMap<BookedRoomsPostDto, BookedRooms>();
    }
}
