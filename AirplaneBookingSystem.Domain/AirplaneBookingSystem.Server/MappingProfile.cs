using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;
namespace AirplaneBookingSystem.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flight, FlightGetDto>();
        CreateMap<Flight, FlightPostDto>();

        CreateMap<FlightPostDto, Flight>();
    }
}
