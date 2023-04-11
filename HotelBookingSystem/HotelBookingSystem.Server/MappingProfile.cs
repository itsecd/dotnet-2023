using AutoMapper;
using HotelBookingSystem.Classes;
using HotelBookingSystem.Server.Dto;

namespace HotelBookingSystem.Server;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Hotel, HotelGetDto>();
        CreateMap<Hotel, HotelPostDto>();
        CreateMap<HotelPostDto, Hotel>();

        CreateMap<Room, RoomGetDto>();
        CreateMap<Room, RoomPostDto>();
        CreateMap<RoomPostDto, Room>();

        CreateMap<Lodger, LodgerGetDto>();
        CreateMap<Lodger, LodgerPostDto>();
        CreateMap<LodgerPostDto, Lodger>();

        CreateMap<BookedRooms, BookedRoomsGetDto>();
        CreateMap<BookedRooms, BookedRoomsPostDto>();
        CreateMap<BookedRoomsPostDto, BookedRooms>();
    }
}
