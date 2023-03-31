using AutoMapper;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<Vehicle, VehiclePostDto>();
        CreateMap<VehiclePostDto, Vehicle>();
        
        CreateMap<RentalPoint, RentalPointGetDto>();
        CreateMap<RentalPoint, RentalPointPostDto>();
        CreateMap<RentalPointPostDto, RentalPoint>();
        
        CreateMap<Client, ClientGetDto>();
        CreateMap<Client, ClientPostDto>();
        CreateMap<ClientPostDto, Client>();
        
        CreateMap<RefundInformation, RefundInformationPostDto>();
        CreateMap<RefundInformationPostDto, RefundInformation>();
        
        CreateMap<RentalInformation, RentalInformationPostDto>();
        CreateMap<RentalInformationPostDto, RentalInformation>();
        
        CreateMap<IssuedCar,IssuedCarPostDto>();
        CreateMap<IssuedCarPostDto, IssuedCar>();
        
        CreateMap<VehicleModel,VehicleModelGetDto>();
    }
}