using Policlinic;
namespace PoliclinicServer.Repository;
/// <summary>
/// Interface for CarSharingRepository
/// </summary>
public interface IPoliclinicRepository
{
    /// <summary>
    /// List of all doctors
    /// </summary>
    List<Doctor> Doctors { get; }
    /// <summary>
    /// List of all patients
    /// </summary>
    List<Patient> Patients { get; }
    /// <summary>
    /// List of all receptions
    /// </summary>
    List<Reception> Receptions { get; }
    /// <summary>
    /// List of all specializations
    /// </summary>
    List<Specialization> Specializations { get; }
}