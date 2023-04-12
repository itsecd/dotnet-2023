using AirLine.Domain;
using Airline.Server.Dto;
using AutoMapper;

namespace Airline.Server;

/// <summary>
/// Class for mapping types
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
        CreateMap<TicketPostDto, Ticket>();
        CreateMap<Airplane, AirplaneGetDto>();
        CreateMap<Airplane, AirplanePostDto>();
        CreateMap<AirplanePostDto, Airplane>();
    }
}