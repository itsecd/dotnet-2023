using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
namespace BicycleRentals.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BicycleType, BicycleTypeGetDto>();

        CreateMap<Bicycle, BicycleGetDto>();
        CreateMap<Bicycle, BicyclePostDto>();
        CreateMap<BicyclePostDto, Bicycle>();

        CreateMap<Customer, CustomerGetDto>();
        CreateMap<Customer, CustomerPostDto>();
        CreateMap<CustomerPostDto, Customer>();

        CreateMap<BicycleRental, RentalGetDto>();
        CreateMap<BicycleRental, RentalPostDto>();
        CreateMap<RentalPostDto, BicycleRental>();
    }
}
