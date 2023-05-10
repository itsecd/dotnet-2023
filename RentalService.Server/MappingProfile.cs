using AutoMapper;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<VehiclePostDto, Vehicle>().ReverseMap();

        CreateMap<RentalPoint, RentalPointGetDto>();
        CreateMap<RentalPointPostDto, RentalPoint>().ReverseMap();
        ;

        CreateMap<Client, ClientGetDto>();
        CreateMap<ClientPostDto, Client>().ReverseMap();

        CreateMap<RefundInformationPostDto, RefundInformation>().ReverseMap();

        CreateMap<RentalInformationPostDto, RentalInformation>().ReverseMap();

        CreateMap<IssuedCarPostDto, IssuedCar>().ReverseMap();

        CreateMap<VehicleModel, VehicleModelGetDto>();
        CreateMap<VehicleModelPostDto, VehicleModel>().ReverseMap();
    }
}