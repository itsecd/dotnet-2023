using AutoMapper;
using TransportManagment.Models;
using TransportManagment.Server.Dto;
namespace TransportManagment.Server;
/// <summary>
/// Class for AutoMapper
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MappingProfile() 
    {
        CreateMap<Models.Route, RouteGetDto>();
        CreateMap<RoutePostDto, Models.Route>();
        CreateMap<Transport, TransportGetDto>();
        CreateMap<TransportPostDto, Transport>();
        CreateMap<Driver, DriverGetDto>();
        CreateMap<DriverPostDto, Driver>();
    }
}
