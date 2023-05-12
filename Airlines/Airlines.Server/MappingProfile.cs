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
        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<Passenger, PassengerPostDto>();
        CreateMap<PassengerPostDto, Passenger>();
        CreateMap<Flight, FlightGetDto>();
        CreateMap<Flight, FlightPostDto>();
        CreateMap<FlightPostDto, Flight>();
        CreateMap<Ticket, TicketPostDto>();
        CreateMap<Ticket, TicketGetDto>();
        CreateMap<TicketPostDto, Ticket>();
        CreateMap<Airplane, AirplaneGetDto>();
        CreateMap<Airplane, AirplanePostDto>();
        CreateMap<AirplanePostDto, Airplane>();
    }
}