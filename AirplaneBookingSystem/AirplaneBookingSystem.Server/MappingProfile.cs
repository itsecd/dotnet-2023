using AirplaneBookingSystem.Model;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;

namespace AirplaneBookingSystem.Server;
/// <summary>
/// Class to mapping types
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Flight, FlightGetDto>();
        CreateMap<Flight, FlightPostDto>();
        CreateMap<FlightPostDto, Flight>();

        CreateMap<Client, ClientGetDto>();
        CreateMap<Client, ClientPostDto>();
        CreateMap<ClientPostDto, Client>();

        CreateMap<Ticket, TicketPostDto>();
        CreateMap<Ticket, TicketGetDto>();
        CreateMap<TicketPostDto, Ticket>();

        CreateMap<Airplane, AirplaneGetDto>();
        CreateMap<Airplane, AirplanePostDto>();
        CreateMap<AirplanePostDto, Airplane>();
    }
}