namespace PoliclinicTests;
using Policlinic;
using System;
using System.Collections.Generic;

public class PoliclinicTestFixture
{
    /// <summary>
    /// Create list of specializations
    /// </summary>
    public List<Specialization> CreateDefaultSpecializations
    {
        get
        {
            return new List<Specialization>()
            {
                new Specialization(1, "Psychotherapist"),
                new Specialization(2, "Dermatologist")
            };
        }
    }
    /// <summary>
    /// Create list of doctors
    /// </summary>
    public List<Doctor> CreateDefaultDoctors
    {
        get
        {
            var receptionList = CreateDefaultReceptions;
            var specializationList = CreateDefaultSpecializations;
            var receptionListSpecial1 = new List<Reception> { receptionList[0], receptionList[1] };
            var receptionListSpecial2 = new List<Reception> { receptionList[2], receptionList[4] };
            var receptionListSpecial3 = new List<Reception> { receptionList[3] };
            return new List<Doctor>()
                {
                    new Doctor(10, "Ivanov Ivan Ivanovich", new DateTime(1975, 12, 1), 7, 1234567890, receptionListSpecial1, 1),
                    new Doctor(11, "Petrov Peter Petrovich", new DateTime(1960, 10, 10), 15, 4321567890, receptionListSpecial2, 2),
                    new Doctor(12, "Smirnov Alexander Alexandrovich", new DateTime(1980, 1, 1), 3, 2341567890, receptionListSpecial3, 1)
                };
        }
    }
    /// <summary>
    /// Create list of patients
    /// </summary>
    public List<Patient> CreateDefaultPatients
    {
        get
        {
            var receptionList = CreateDefaultReceptions;
            var receptionListSpecial1 = new List<Reception> { receptionList[0] };
            var receptionListSpecial2 = new List<Reception> { receptionList[1], receptionList[4] };
            var receptionListSpecial3 = new List<Reception> { receptionList[2] };
            var receptionListSpecial4 = new List<Reception> { receptionList[3] };
            return new List<Patient>
                {
                    new Patient(1000, 4231123456, "Ivanov Pyotr Vladimirovich", new DateTime(2000, 2, 2), "Moskovskoe highway 34b", receptionListSpecial1),
                    new Patient(1001, 1234123456, "Belov Evgeny Maksimovich", new DateTime(1990, 7, 6), "231 Kirov Street", receptionListSpecial2),
                    new Patient(1002, 1423123456, "Kirov Lukas Markovich", new DateTime(1993, 8, 8), "Michurina Street 15", receptionListSpecial3),
                    new Patient(1003, 4321123456, "Krylov Vladimir Petrovich", new DateTime(1985, 1, 1), "17 Banykin Street", receptionListSpecial4)
                };
        }
    }
    /// <summary>
    /// Create list of receptions
    /// </summary>
    public List<Reception> CreateDefaultReceptions
    {
        get
        {
            return new List<Reception>()
                {
                    new Reception(100, new DateTime(2023, 2, 1, 12, 0, 0), "On treatment", 10, 1000, "Nervousness"),
                    new Reception(110, new DateTime(2023, 2, 1, 12, 15, 0), "Healthy", 10, 1001, ""),
                    new Reception(120, new DateTime(2023, 2, 2, 11, 0, 0), "Healthy", 11, 1002, ""),
                    new Reception(130, new DateTime(2023, 2, 3, 13, 45, 0), "On treatment", 12, 1003, "Psoriasis"),
                    new Reception(140, new DateTime(2023, 2, 1, 12, 30, 0), "Healthy", 11, 1001, ""),
                };
        }
    }
}
