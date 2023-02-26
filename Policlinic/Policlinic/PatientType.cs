using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Policlinic;

public class PatientType
{
    public string Passport { get; set; } = string.Empty;

    public string FIO { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; } = DateTime.MinValue;

    public string Address { get; set; } = string.Empty;

    public PatientType() { }

    public PatientType(string passport, string fIO, DateTime birthDate, string address)
    {
        Passport = passport;
        FIO = fIO;
        BirthDate = birthDate;
        Address = address;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PatientType param)
            return false;
        return Passport == param.Passport && FIO == param.FIO && BirthDate == param.BirthDate && Address == param.Address;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport, FIO, BirthDate, Address);
    }
}
