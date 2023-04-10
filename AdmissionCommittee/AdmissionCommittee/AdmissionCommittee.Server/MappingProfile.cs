using AdmissionCommittee.Server.Dto;
using AutoMapper;

namespace AdmissionCommittee.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Entrant, EntrantGetDto>();
        CreateMap<Entrant, EntrantPostDto>();
        CreateMap<EntrantPostDto, Entrant>();

        CreateMap<ResultPostDto, Result>();
        CreateMap<Result, ResultPostDto>();


        CreateMap<Specialty, SpecialityPostDto>();
        CreateMap<SpecialityPostDto, Specialty>();

        CreateMap<Statement, StatementGetDto>();
    }
}