namespace PoliclinicTests;
using Policlinic;
using System;
using System.Collections.Generic;

public class PoliclinicTestFixture
{
    public List<SpecializationType> CreateDefaultSpecializations()
    {
        return new List<SpecializationType>()
        {
            new SpecializationType(1, "Психотерапевт"),
            new SpecializationType(2, "Дерматолог")
        };
    }

    public List<DoctorType> CreateDefaultDoctors()
    {
        var specializationList = CreateDefaultSpecializations();
        return new List<DoctorType>()
        {
            new DoctorType(1234567890, "Иванов Иван Иванович", new DateTime(1975, 12, 1), 7, specializationList[0].Id),
            new DoctorType(4321567890, "Петров Петр Петрович", new DateTime(1960, 10, 10), 15, specializationList[1].Id),
            new DoctorType(2341567890, "Смирнов Александр Александрович", new DateTime(1980, 1, 1), 3, specializationList[0].Id)
        };
    }

    public List<PatientType> CreateDefaultPatients()
    {
        return new List<PatientType>
        {
            new PatientType(4231123456, "Иванов Петр Владимирович", new DateTime(2000, 2, 2), "Московское шоссе 34б"),
            new PatientType(1234123456, "Белов Евгений Максимович", new DateTime(1990, 7, 6), "Улица Кирова 231"),
            new PatientType(1423123456, "Киров Лукас Маркович", new DateTime(1993, 8, 8), "Улица Мичурина 15"),
            new PatientType(4321123456, "Крылов Владимир Петрович", new DateTime(1995, 1, 1), "Улица Баныкина 17")
        };
    }

    public List<ReceptionType> CreateDefaultReceptions()
    {
        var patientList = CreateDefaultPatients();
        var doctorList = CreateDefaultDoctors();
        return new List<ReceptionType>()
        {
            new ReceptionType(new DateTime(2023, 2, 1, 12, 0, 0), "На лечении", doctorList[0].Passport, patientList[0].Passport, "Нервоз"),
            new ReceptionType(new DateTime(2023, 2, 1, 12, 15, 0), "Здоров", doctorList[0].Passport, patientList[1].Passport, ""),
            new ReceptionType(new DateTime(2023, 2, 2, 11, 0, 0), "Здоров", doctorList[1].Passport, patientList[2].Passport, ""),
            new ReceptionType(new DateTime(2023, 2, 3, 13, 45, 0), "На лечении", doctorList[2].Passport, patientList[3].Passport, "Псориаз"),
            new ReceptionType(new DateTime(2023, 2, 1, 12, 30, 0), "Здоров", doctorList[1].Passport, patientList[1].Passport, ""),
        };
    }
}
