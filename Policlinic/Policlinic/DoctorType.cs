using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinic;
using Policlinic;
public class DoctorType
{
    public string Passport { get; set; } = string.Empty;

    public string FIO { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public int WorkExperience { get; set; }

    //добавить специализации
    public SpecializationType Specialization { get; set; }

    public DoctorType() { }

    public DoctorType (string passport, string fIO, DateTime birthDate, int workExperience, SpecializationType specialization)
    {
        Passport = passport;
        FIO = fIO;
        BirthDate = birthDate;
        WorkExperience = workExperience;
        Specialization = specialization;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DoctorType param)
            return false;
        return Passport == param.Passport && FIO == param.FIO && BirthDate == param.BirthDate && WorkExperience == param.WorkExperience && Specialization == param.Specialization;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport, FIO, BirthDate, WorkExperience, Specialization);
    }
}
