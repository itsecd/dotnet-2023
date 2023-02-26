using System.Security.Cryptography;
using Xunit.Sdk;
using Policlinic;

namespace PoliclinicTests;

public class PoliclinicTest
{
    private List<SpecializationType> CreateDefaultSpecializations()
    {
        return new List<SpecializationType>()
        {
            new SpecializationType("Психотерапевт"),
            new SpecializationType("Дерматолог")
        };
    }

    private List<DoctorType> CreateDefaultDoctors()
    {
        var specializationList = CreateDefaultSpecializations();
        return new List<DoctorType>()
        {
            new DoctorType("1234 567890", "Иванов Иван Иванович", new DateTime(1975, 12, 1), 7, specializationList[0]),
            new DoctorType("4321 567890", "Петров Петр Петрович", new DateTime(1960, 10, 10), 15, specializationList[1]),
            new DoctorType("2341 567890", "Смирнов Александр Александрович", new DateTime(1980, 1, 1), 3, specializationList[0])
        };
    }

    private List<PatientType> CreateDefaultPatients()
    {
        return new List<PatientType>
        {
            new PatientType("4231 123456", "Иванов Петр Владимирович", new DateTime(2000, 2, 2), "Московское шоссе 34б"),
            new PatientType("1234 123456", "Белов Евгений Максимович", new DateTime(1990, 7, 6), "Улица Кирова 231"),
            new PatientType("1423 123456", "Киров Лукас Маркович", new DateTime(1993, 8, 8), "Улица Мичурина 15"),
            new PatientType("4321 123456", "Крылов Владимир Петрович", new DateTime(1995, 1, 1), "Улица Баныкина 17")
        };
    }

    private List<ReceptionType> CreateDefaultReceptions()
    {
        var patientList = CreateDefaultPatients();
        var doctorList = CreateDefaultDoctors();
        return new List<ReceptionType>()
        {
            new ReceptionType(new DateTime(2023, 2, 1, 12, 0, 0), "На лечении", doctorList[0], patientList[0]),
            new ReceptionType(new DateTime(2023, 2, 1, 12, 15, 0), "Здоров", doctorList[0], patientList[1]),
            new ReceptionType(new DateTime(2023, 2, 2, 11, 0, 0), "Здоров", doctorList[1], patientList[2]),
            new ReceptionType(new DateTime(2023, 2, 3, 13, 45, 0), "На лечении", doctorList[2], patientList[3]),
        };
    }

    [Fact]
    public void SpecializationConstructorTest()
    {
        var specialization = new SpecializationType("Психотерапевт");
        Assert.Equal("Психотерапевт", specialization.Specialization);
    }

    [Fact]
    public void DoctorConstructorTest() 
    {
        var specializationList = CreateDefaultSpecializations();
        var doctor = new DoctorType("1234 567890", "Иванов Иван Иванович", new DateTime(1975, 12, 1), 7, specializationList[0]);
        Assert.Equal("1234 567890", doctor.Passport);
        Assert.Equal("Иванов Иван Иванович", doctor.FIO);
        Assert.Equal(new DateTime(1975, 12, 1), doctor.BirthDate);
        Assert.Equal(7, doctor.WorkExperience);
        Assert.Equal(specializationList[0], doctor.Specialization);
    }
}