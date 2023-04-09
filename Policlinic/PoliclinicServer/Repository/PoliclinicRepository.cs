using Policlinic;
namespace PoliclinicServer.Repository;

/// <summary>
/// Data repository to contain all data
/// </summary>
public class PoliclinicRepository : IPoliclinicRepository
{
    private readonly List<Specialization> _specializations;
    private readonly List<Doctor> _doctors;
    private readonly List<Patient> _patients;
    private readonly List<Reception> _receptions;

    /// <summary>
    /// Constructor for PoliclinicRepository
    /// </summary>
    public PoliclinicRepository()
    {
        _receptions = new List<Reception>()
        {
            new Reception(10, new DateTime(2023, 2, 1, 12, 0, 0), "On treatment", 1, 1000, "Nervousness"),
            new Reception(11, new DateTime(2023, 2, 1, 12, 15, 0), "Healthy", 1, 1001, ""),
            new Reception(12, new DateTime(2023, 2, 2, 11, 0, 0), "Healthy", 2, 1002, ""),
            new Reception(13, new DateTime(2023, 2, 3, 13, 45, 0), "On treatment", 3, 1003, "Psoriasis"),
            new Reception(14, new DateTime(2023, 2, 1, 12, 30, 0), "Healthy", 2, 1001, ""),
        };
        _specializations = new List<Specialization>()
        {
            new Specialization(1, "Psychotherapist"),
            new Specialization(2, "Dermatologist")
        };
        _doctors = new List<Doctor>()
        {
            new Doctor(1, "Ivanov Ivan Ivanovich", new DateTime(1975, 12, 1), 7, 1, 100, 1234567890, _specializations[0], new List < Reception >() { _receptions[0], _receptions[1] }),
            new Doctor(2, "Petrov Peter Petrovich", new DateTime(1960, 10, 10), 15, 2, 120, 4321567890, _specializations[1],new List<Reception>(){_receptions[2], _receptions[4] }),
            new Doctor(3, "Smirnov Alexander Alexandrovich", new DateTime(1980, 1, 1), 3, 1, 130, 2341567890, _specializations[0], new List < Reception >() { _receptions[3] })
        };
        _patients = new List<Patient>()
        {
            new Patient(1000, 4231123456, "Ivanov Pyotr Vladimirovich", new DateTime(2000, 2, 2), "Moskovskoe highway 34b", new List<Reception>(){ _receptions[0] }, 100),
            new Patient(1001, 1234123456, "Belov Evgeny Maksimovich", new DateTime(1990, 7, 6), "231 Kirov Street", new List<Reception>(){ _receptions[1], _receptions[4] }, 110),
            new Patient(1002, 1423123456, "Kirov Lukas Markovich", new DateTime(1993, 8, 8), "Michurina Street 15", new List<Reception>(){_receptions[2] }, 120),
            new Patient(1003, 4321123456, "Krylov Vladimir Petrovich", new DateTime(1985, 1, 1), "17 Banykin Street", new List<Reception>(){ _receptions[3]}, 130)
        };
    }

    /// <summary>
    /// List of all specializations and info about it
    /// </summary>
    public List<Specialization> Specializations => _specializations;
    /// <summary>
    /// List of all doctors and info about them
    /// </summary>
    public List<Doctor> Doctors => _doctors;
    /// <summary>
    /// List of all patients and info about them
    /// </summary>
    public List<Patient> Patients => _patients;
    /// <summary>
    /// List of all receptions and info about it
    /// </summary>
    public List<Reception> Receptions => _receptions;
}
