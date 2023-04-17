using AutoMapper;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server;
public class MappingProfile : Profile
{

    public MappingProfile()
    {
        //CreateMap<Registration, RegistrationPostDto>();
        CreateMap<RegistrationPostDto, Registration>();

        CreateMap<Doctor, DoctorGetDto>();
        //CreateMap<Doctor, DoctorPostDto>();
        CreateMap<DoctorPostDto, Doctor>();

        //CreateMap<Completion, CompletionPostDto>();
        CreateMap<CompletionPostDto, Completion>();

        CreateMap<Patient, PatientGetDto>();
        //CreateMap<Patient, PatientPostDto>();
        CreateMap<PatientPostDto, Patient>();
    }
}