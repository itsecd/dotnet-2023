using Polyclinic.Domain;
namespace Polyclinic.Test;

public class PolyclinicTest
{
    [Fact]
    private List<Specializations> CreateSpecializationList()
    {
        return new List<Specializations>()
        {
            new Specializations(1, "Surgeon"),
            new Specializations(2,"Neurologist"),
            new Specializations(3,"Gynecologist"),
            new Specializations(4, "Therapist"),
            new Specializations(5,"Psychiatrist")
        };
    }
    /// <summary>
    /// creating a list of patients
    /// </summary>
    [Fact]
    private List<Patient> CreatePatientList()
    {
        return new List<Patient>()
        {
            new Patient(11111111,"Margaret Schultz",new DateOnly(1990,1,1),"408 Eddie Fords Port Arthurburgh",1),
            new Patient(22222222, "Sandra Allen", new DateOnly(1980,2,2),"21183 Ian Corner North Kendrick",2),
            new Patient(33333333, "Jamie Brown", new DateOnly(1976,3,3),"72634 Thiel Island Bodefort",3),
            new Patient(44444444,"Carlos Weaver", new DateOnly(1987,4,4), "4310 Hauck Gateway Heaneyview", 4),
            new Patient(55555555, "Frances Cooper", new DateOnly(1965,5,5), "1418 Graham Plain East Chet", 5)
        };
    }

    /// <summary>
    /// creating a list of doctors
    /// </summary>
    [Fact]
    private List<Doctor> CreateDoctorList()
    {
        return new List<Doctor>()
        {
            new Doctor(66666666,"Melissa Sparks", new DateOnly(1970,6,6), 1, 15, 1),
            new Doctor(77777777,"John Garcia", new DateOnly(1988,7,7), 2, 10,2),
            new Doctor(88888888, "Brian Sullivan", new DateOnly(1979,8,8), 3, 8, 3),
            new Doctor(99999999,"Laura Harris", new DateOnly(1967,9,9), 4, 25, 4),
            new Doctor(10101010, "Francis Reynolds", new DateOnly(1980,10,10),5, 6, 5)
        };
    }

    /// <summary>
    /// creating a list of registered patients
    /// </summary>
    [Fact]
    private List<Registration> CreateRegList()
    {
        return new List<Registration>()
        {
            new Registration(1,1,3,new DateTime(2023,4,5,15,0,0)),
            new Registration(2,2,1,new DateTime(2023,4,2,12,0,0)),
            new Registration(3,3,2,new DateTime(2023,3,19,14,30,0)),
            new Registration(4,4,4,new DateTime(2023,4,15,13,0,0)),
            new Registration(5,5,5,new DateTime(2023,4,2,13,0,0)),
            new Registration(6,2,3, new DateTime(2023, 4,5,13,0,0)),
            new Registration(7,5,2,new DateTime(2023,3,2,13,0,0))
        };
    }

    /// <summary>
    /// creating a list of admitted patients
    /// </summary>
    [Fact]
    private List<Completion> CreateComList()
    {
        return new List<Completion>()
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

    /// <summary>
    /// Display information about all doctors with at least 10 years of experience
    /// </summary>
    [Fact]
    public void Test1()
    {
        var doctors = CreateDoctorList();

        var result = from d in doctors
                     where d.WorkExperience >= 10
                     select d;

        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
        Assert.Contains(result, x => x.FullName == "Melissa Sparks");
        Assert.DoesNotContain(result, x => x.FullName == "Brian Sullivan");
    }

    /// <summary>
    /// Display information about all patients registered with the specified doctor, sorted by full name.
    /// </summary>
    [Fact]
    public void Test2()
    {
        var doctors = CreateDoctorList();
        var patients = CreatePatientList();
        var registrations = CreateRegList();

        var result = from reg in registrations
                     join p in patients on reg.IdPatient equals p.Id
                     join d in doctors on reg.IdDoctor equals d.Id
                     where d.FullName == "Brian Sullivan"
                     orderby p.FullName
                     select p;

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.FullName == "Margaret Schultz");
        Assert.DoesNotContain(result, x => x.FullName == "Carlos Weaver");
    }

    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    [Fact]
    public void Test3()
    {
        var completions = CreateComList();
        var patients = CreatePatientList();

        var result = from c in completions
                     join p in patients on c.IdPatient equals p.Id
                     where c.Status == 1
                     select p;

        Assert.NotNull(result);
        Assert.Equal(4, result.Count());
        Assert.Contains(result, x => x.FullName == "Margaret Schultz");
        Assert.DoesNotContain(result, x => x.FullName == "Frances Cooper");
    }

    /// <summary>
    /// Display information about the number of appointments of patients by doctors for the last month.
    /// </summary>
    [Fact]
    public void Test4()
    {
        var registrations = CreateRegList();
        var doctors = CreateDoctorList();
        var patients = CreatePatientList();
        var lastMonth1 = new DateTime(2023, 4, 1);
        var lastMonth2 = new DateTime(2023, 4, 30);

        var result = from r in registrations
                     join p in patients on r.IdPatient equals p.Id
                     join d in doctors on r.IdDoctor equals d.Id
                     where r.TimeAdmission >= lastMonth1 && r.TimeAdmission <= lastMonth2
                     group r by d into dGroup
                     select new { Doctor = dGroup.Key.FullName, Appointments = dGroup.Count() };

        Assert.NotNull(result);
        Assert.Contains(result, x => x.Doctor == "Melissa Sparks" && x.Appointments == 1);
        Assert.Contains(result, x => x.Doctor == "Brian Sullivan" && x.Appointments == 2);
        Assert.DoesNotContain(result, x => x.Doctor == "John Garcia");
    }

    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    [Fact]

    public void Test5()
    {
        var completions = CreateComList();
        var patients = CreatePatientList();

        var result = (from c in completions
                      join p in patients on c.IdPatient equals p.Id
                      group c by c.Conclusion into g
                      orderby g.Count() descending
                      select new { Disease = g.Key, Count = g.Count() }).Take(5).ToList();

        Assert.NotNull(result);
        Assert.Equal(5, result.Count);
        Assert.Equal("viral disease", result[0].Disease);
        Assert.Contains(result, x => x.Disease == "pneumonia" && x.Count == 2);
        Assert.DoesNotContain(result, x => x.Disease == "bronchitis");

    }

    /// <summary>
    /// Display information about patients over 30 years of age who have appointments with several doctors, sorted by date of birth.
    /// </summary>
    [Fact]
    public void Test6()
    {
        var registrations = CreateRegList();
        var patients = CreatePatientList();

        var result = from p in patients
                     let age = (int)(DateOnly.FromDateTime(DateTime.Today).Year - p.DateBirth.Year / 365)
                     where age > 30
                     join r in registrations on p.Id equals r.IdPatient into appointments
                     where appointments.GroupBy(a => a.IdDoctor).Count() > 1
                     orderby p.DateBirth
                     select p;

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.FullName == "Sandra Allen");
        Assert.Contains(result, x => x.FullName == "Frances Cooper");
        Assert.DoesNotContain(result, x => x.FullName == "Margaret Schultz");
    }
}