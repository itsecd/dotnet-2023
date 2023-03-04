using Polyclinic.Domain;
namespace Polyclinic.Test;

public class UnitTest
{
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

    [Fact]
    private List<Doctor> CreateDoctorList()
    {
        return new List<Doctor>()
        {
            new Doctor(66666666,"Melissa Sparks", new DateOnly(1970,6,6), "Surgeon",15,1),
            new Doctor(77777777,"John Garcia", new DateOnly(1988,7,7), "Neurologist", 10,2),
            new Doctor(88888888, "Brian Sullivan", new DateOnly(1979,8,8), "Gynecologist", 8, 3),
            new Doctor(99999999,"Laura Harris", new DateOnly(1967,9,9), "Therapist", 25, 4),
            new Doctor(10101010, "Francis Reynolds", new DateOnly(1980,10,10),"Psychiatrist", 6, 5)
        };
    }

    [Fact]
    private List<Registration> CreateRegList()
    {
        return new List<Registration>()
        {
            new Registration(1,3,new DateTime(2023,4,5,15,0,0)),
            new Registration(2,1,new DateTime(2023,4,2,12,0,0)),
            new Registration(3,2,new DateTime(2023,3,19,14,30,0)),
            new Registration(4,4,new DateTime(2023,4,15,13,0,0)),
            new Registration(5,5,new DateTime(2023,4,2,13,0,0)),
            new Registration(2,3, new DateTime(2023, 4,5,13,0,0))
        };
    }

    [Fact]
    private List<Completion> CreateComList()
    {
        return new List<Completion>()
        {
            new Completion(1,3,1,"..."),
            new Completion(2,1,1,"..."),
            new Completion(3,2,0,"..."),
            new Completion(4,4,1,"..."),
            new Completion(5,5,0,"..."),
        };
    }

    [Fact]
    //Вывести информацию о всех врачах, стаж работы которых не меньше 10 лет
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

    //Вывести информацию о всех пациентах, записанных на прием к указанному врачу.
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
                     select p;
        
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.FullName == "Margaret Schultz");
        Assert.DoesNotContain(result, x => x.FullName == "Carlos Weaver");
    }

    //Вывести информацию о здоровых на настоящий момент пациентах.
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
        Assert.Equal(3, result.Count());
        Assert.Contains(result, x => x.FullName == "Margaret Schultz");
        Assert.DoesNotContain(result, x => x.FullName == "Frances Cooper");
    }

    
}