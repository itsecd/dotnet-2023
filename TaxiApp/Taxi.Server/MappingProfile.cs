using AutoMapper;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DriverSetDto, Driver>();
        CreateMap<Vehicle, VehicleSetDto>();
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<PassengerSetDto, Passenger>();
        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<RideSetDto, Ride>()
            .ForMember(ride => ride.RideTime, s =>
                s.MapFrom(ride => TimeSpan.FromSeconds(ride.RideTime)));
    }
}