using Polyclinic.Domain;

namespace Polyclinic.Server.Repository;

public class PolyclinicRepository : IPolyclinicRepository
{
    private readonly List<Specializations> _specializations;
    private readonly List<Doctor> _doctors;
    private readonly List<Patient> _patients;
    private readonly List<Registration> _registration;
    private readonly List<Completion> _completion;

    public PolyclinicRepository()
    {
        _specializations = new List<Specializations>()
        {
            new Specializations(1, "Surgeon"),
            new Specializations(2,"Neurologist"),
            new Specializations(3,"Gynecologist"),
            new Specializations(4, "Therapist"),
            new Specializations(5,"Psychiatrist")
        };

        _doctors = new List<Doctor>()
        {
            new Doctor(66666666,"Melissa Sparks", new DateTime(1970,6,6), 1, 15, 1),
            new Doctor(77777777,"John Garcia", new DateTime(1988,7,7), 2, 10,2),
            new Doctor(88888888, "Brian Sullivan", new DateTime(1979,8,8), 3, 8, 3),
            new Doctor(99999999,"Laura Harris", new DateTime(1967,9,9), 4, 25, 4),
            new Doctor(10101010, "Francis Reynolds", new DateTime(1980,10,10),5, 6, 5)
        };

        _patients = new List<Patient>()
        {
            new Patient(11111111,"Margaret Schultz",new DateTime(1990,1,1),"408 Eddie Fords Port Arthurburgh",1),
            new Patient(22222222, "Sandra Allen", new DateTime(1980,2,2),"21183 Ian Corner North Kendrick",2),
            new Patient(33333333, "Jamie Brown", new DateTime(1976,3,3),"72634 Thiel Island Bodefort",3),
            new Patient(44444444,"Carlos Weaver", new DateTime(1987,4,4), "4310 Hauck Gateway Heaneyview", 4),
            new Patient(55555555, "Frances Cooper", new DateTime(1965,5,5), "1418 Graham Plain East Chet", 5)
        };

        _registration = new List<Registration>()
        {
            new Registration(1,1,3,new DateTime(2023,4,5,15,0,0)),
            new Registration(2,2,1,new DateTime(2023,4,2,12,0,0)),
            new Registration(3,3,2,new DateTime(2023,3,19,14,30,0)),
            new Registration(4,4,4,new DateTime(2023,4,15,13,0,0)),
            new Registration(5,5,5,new DateTime(2023,4,2,13,0,0)),
            new Registration(6,2,3, new DateTime(2023, 4,5,13,0,0)),
            new Registration(7,5,2,new DateTime(2023,3,2,13,0,0))
        };

        _completion = new List<Completion>()
        {
            new Completion(1,1,3,1,"viral disease"),
            new Completion(2,2,1,1,"viral disease"),
            new Completion(3,3,2,0,"quinsy"),
            new Completion(4,4,4,0,"pneumonia"),
            new Completion(5,5,5,0,"depression"),
            new Completion(6,1,4,0,"pneumonia"),
            new Completion(7,2,4,0,"viral disease"),
            new Completion(8,3,4,0,"tuberculosis"),
            new Completion(9,2,2,1,"tuberculosis"),
            new Completion(10,3,5,1,"depression"),
            new Completion(11,1,2,0,"quinsy"),
            new Completion(12,2,4,0,"bronchitis")
        };

    }

    public List<Specializations> Specializations => _specializations;
    public List<Completion> Completions => _completion;
    public List<Registration> Registrations => _registration;
    public List<Doctor> Doctors => _doctors;
    public List<Patient> Patients => _patients;

}
