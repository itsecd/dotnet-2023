using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinic;
using Policlinic;
public class ReceptionType
{
    public DateTime DateAndTime { get; set; }

    //public DateTime Time { get; set; }

    public string Status { get; set; } = string.Empty;

    public DoctorType Doctor { get; set; } = new();

    public PatientType Patient { get; set; } = new();

    public ReceptionType() { }

    public ReceptionType(DateTime dateAndTime, string status, DoctorType doctor, PatientType patient)
    {
        DateAndTime = dateAndTime;
        //Time = time;
        Status = status;
        Doctor = doctor;
        Patient = patient;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ReceptionType param)
            return false;
        return Doctor.Equals(param.Doctor) && Patient.Equals(param.Patient) &&
             DateAndTime == param.DateAndTime && Status == param.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Doctor, Patient, DateAndTime, Status);
    }
}
