using Airline.Server.Dto;
using AirLine.Model;
using AirlineClasses;
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
        CreateMap<PassengerPostDto, Passenger>();

        CreateMap<Flight, FlightGetDto>();
        CreateMap<FlightPostDto, Flight>();

        CreateMap<Ticket, TicketGetDto>();
        CreateMap<TicketPostDto, Ticket>();

        CreateMap<Airplane, AirplaneGetDto>();
        CreateMap<AirplanePostDto, Airplane>();

        CreateMap<FlightAirplaneTicket, FlightAirplaneTicketGetDto>();
        CreateMap<FlightAirplaneTicketPostDto, FlightAirplaneTicket>();
    }
}