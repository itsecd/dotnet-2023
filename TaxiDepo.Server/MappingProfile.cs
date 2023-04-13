using AutoMapper;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server;

/// <summary>
/// 
/// </summary>
public class MappingProfile: Profile
{
    /// <summary>
    /// 
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
        CreateMap<Driver, DriverDto>();
        CreateMap<DriverDto, Driver>();
        CreateMap<Ride, RideDto>();
        CreateMap<RideDto, Ride>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
} 