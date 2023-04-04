using AutoMapper;
using CarSharingDomain;
using CarSharingServer.Dto;

namespace CarSharingServer;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<Client, ClientGetDto>();
        CreateMap<ClientGetDto, Client>();
        CreateMap<Client, ClientPostDto>();
        CreateMap<ClientPostDto, Client>();
        CreateMap<Car, CarGetDto>();
        CreateMap<Car, CarPostDto>();
        CreateMap<CarGetDto, Car>();
        CreateMap<CarPostDto, Car>();
        CreateMap<RentalPoint, RentalPointPostDto>();
        CreateMap<RentalPointPostDto, RentalPoint>();
    }
}
