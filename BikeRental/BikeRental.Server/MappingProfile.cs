using AutoMapper;
using BikeRental.Server.Dto;
using BikeRental.Domain;

namespace BikeRental.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Bike, BikeGetDto>();
        CreateMap<Bike, BikeSetDto>();
    }
}
