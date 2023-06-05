using AutoMapper;
using TransportManagment.Model;
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
        CreateMap<Model.Route, RouteGetDto>();
        CreateMap<RoutePostDto, Model.Route>();
        CreateMap<Transport, TransportGetDto>();
        CreateMap<TransportPostDto, Transport>();
        CreateMap<Driver, DriverGetDto>();
        CreateMap<DriverPostDto, Driver>();
    }
}
