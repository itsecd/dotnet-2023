using AutoMapper;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DriverSetDto, Driver>();
        CreateMap<VehicleSetDto, Vehicle>();
        CreateMap<PassengerSetDto, Passenger>();
        CreateMap<RideSetDto, Ride>()
            .ForMember(ride => ride.RideTime, s =>
                s.MapFrom(ride => TimeSpan.FromSeconds(ride.RideTime)));
        CreateMap<Vehicle, VehicleSetDto>();
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<Passenger, PassengerGetDto>();
        CreateMap<Ride, RideGetDto>();
        CreateMap<RideGetDto, Ride>();
    }
}