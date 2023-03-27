using AutoMapper;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DriverPostDto, Driver>();
        CreateMap<Vehicle, VehiclePostDto>();
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<PassengerPostDto, Passenger>();
        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<RidePostDto, Ride>()
            .ForMember(ride => ride.RideTime, s =>  s.MapFrom(ride => TimeSpan.FromSeconds(ride.RideTime)));
    }
}