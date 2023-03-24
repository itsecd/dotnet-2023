using AutoMapper;
using BicycleRentals;
using BicycleSever.Dto;

namespace BicycleSever;
public class MappingProfile : Profile
{
    public MappingProfile() {
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
