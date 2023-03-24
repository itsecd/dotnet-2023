using Airlines.Domain;
using Airlines.Server.Dto;
using AutoMapper;

namespace Airlines.Server;

/// <summary>
/// Class to mapping types
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PassengerClass, PassengerGetDto>();
        CreateMap<PassengerClass, PassengerPostDto>();
        CreateMap<PassengerPostDto, PassengerClass>();
        CreateMap<FlightCLass, FlightGetDto>();
        CreateMap<FlightCLass, FlightPostDto>();
        CreateMap<FlightPostDto, FlightCLass>();
        CreateMap<TicketClass, TicketPostDto>();
        CreateMap<TicketPostDto, TicketClass>();
        CreateMap<AirplaneClass, AirplaneGetDto>();
        CreateMap<AirplaneClass, AirplanePostDto>();
        CreateMap<AirplanePostDto, AirplaneClass>();
    }
}
