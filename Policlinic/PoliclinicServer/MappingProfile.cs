using AutoMapper;
using Policlinic;
using PoliclinicServer.Dto;
namespace PoliclinicServer;
/// <summary>
/// MappingProfile to map Dto objects on Domain objects and  backwards
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor for MappingProfile
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Doctor, DoctorGetDto>();
        CreateMap<Doctor, DoctorPostDto>();
        CreateMap<DoctorPostDto, Doctor>();
        CreateMap<Patient, PatientGetDto>();
        CreateMap<Patient, PatientPostDto>();
        CreateMap<PatientPostDto, Patient>();
        CreateMap<Reception, ReceptionDto>();
        CreateMap<ReceptionDto, Reception>();
        CreateMap<Specialization, SpecializationDto>();
        CreateMap<SpecializationDto, Specialization>();
    }
}
