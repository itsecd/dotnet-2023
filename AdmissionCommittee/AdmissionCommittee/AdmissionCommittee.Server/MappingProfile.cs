using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;

namespace AdmissionCommittee.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Specialty, SpecialtyGetDto>();
        CreateMap<SpecialtyPostDto, Specialty>();

        CreateMap<Result, ResultGetDto>();
        CreateMap<ResultPostDto, Result>();

        CreateMap<Statement, StatementGetDto>();
        CreateMap<StatementPostDto, Statement>();

        CreateMap<StatementSpecialty, StatementSpecialtyGetDto>();
        CreateMap<StatementSpecialtyPostDto, StatementSpecialty>();

        CreateMap<Entrant, EntrantGetDto>();
        CreateMap<Entrant, EntrantPostDto>();
        CreateMap<EntrantPostDto, Entrant>();

        CreateMap<EntrantResult, EntrantResultGetDto>();
        CreateMap<EntrantResult, EntrantResultPostDto>();
        CreateMap<EntrantResultPostDto, EntrantResult>();
    }
}