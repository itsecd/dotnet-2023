using AutoMapper;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server;
public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Registration, RegistrationGetDto>();
        CreateMap<RegistrationPostDto, Registration>();

        CreateMap<Doctor, DoctorGetDto>();
        CreateMap<DoctorPostDto, Doctor>();

        CreateMap<Completion, CompletionGetDto>();
        CreateMap<CompletionPostDto, Completion>();

        CreateMap<Patient, PatientGetDto>();
        CreateMap<PatientPostDto, Patient>();

        CreateMap<Specializations, SpecializationsGetDto>();
        CreateMap<SpecializationsGetDto, Specializations>();
    }
}