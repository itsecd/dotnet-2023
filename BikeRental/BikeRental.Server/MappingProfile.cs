using AutoMapper;
using BikeRental.Domain;
using BikeRental.Server.Dto;

namespace BikeRental.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Bike, BikeGetDto>();
        CreateMap<Bike, BikeSetDto>();
        CreateMap<BikeGetDto, Bike>();
        CreateMap<BikeSetDto, Bike>();

        CreateMap<Client, ClientGetDto>();
        CreateMap<Client, ClientSetDto>();
        CreateMap<ClientGetDto, Client>();
        CreateMap<ClientSetDto, Client>();

        CreateMap<BikeType, BikeTypeGetDto>();
        CreateMap<BikeTypeGetDto, BikeType>();

        CreateMap<RentRecord, RentRecordGetDto>();
        CreateMap<RentRecord, RentRecordSetDto>();
        CreateMap<RentRecordGetDto, RentRecord>();
        CreateMap<RentRecordSetDto, RentRecord>();
    }
}
