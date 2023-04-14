using Polyclinic.Domain;

namespace Polyclinic.Server.Repository;

public interface IPolyclinicRepository
{
    List<Specializations> Specializations { get; }
    List<Doctor> Doctors { get; }
    List<Patient> Patients { get; }
    List<Registration> Registrations { get; }
    List<Completion> Completions { get; }
}
