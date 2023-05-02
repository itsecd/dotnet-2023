using AutoMapper;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server;

/// <summary>
/// MappingProfile class
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor without params
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Ride, RideDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}