using AutoMapper;
using CarSharingDomain;
using CarSharingServer.Dto;

namespace CarSharingServer;
/// <summary>
/// MappingProfile to map Dto objects on Domain objects and  backwards
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor for MappingProfile
    /// </summary>
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
        CreateMap<RentedCar, RentedCarGetDto>();
        CreateMap<RentedCarGetDto, RentedCar>();
        CreateMap<RentedCar, RentedCarPostDto>();
        CreateMap<RentedCarPostDto, RentedCar>();
    }
}
