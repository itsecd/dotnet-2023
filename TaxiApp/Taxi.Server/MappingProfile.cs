using AutoMapper;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Driver, DriverPostDto>();
        CreateMap<DriverPostDto, Driver>();
        CreateMap<Vehicle, VehiclePostDto>();
        CreateMap<VehiclePostDto, Vehicle>();
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<Passenger, PassengerPostDto>();
        CreateMap<PassengerPostDto, Passenger>();
        CreateMap<Passenger, PassengerGetDto>();

    }
}