using System.ComponentModel.DataAnnotations;
namespace Policlinic;

/// <summary>
/// Patient describes a patient
/// </summary>
public class Patient
{
    /// <summary>
    /// Id is an int typed value of the patient's id
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Passport is a long int typed value of the passport series and number
    /// </summary>
    public long Passport { get; set; }
    /// <summary>
    ///  Fio is a string typed value for storing the name, surname and patronymic of the patient
    /// </summary>
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate is a datetime value of a doctor's birthday
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Address is a string typed value of the patient's address
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Receptions is a list of receptions
    /// </summary>
    public List<Reception> Receptions { get; set; } = new List<Reception>();
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Patient() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id">Patient's id</param>
    /// <param name="passport">Patient's number of passport</param>
    /// <param name="fio">Patient's FIO</param>
    /// <param name="birthDate">Patient's birth date</param>
    /// <param name="address">Patient's address</param>
    /// <param name="receptions">Receptions</param>
    public Patient(int id, long passport, string fio, DateTime birthDate, string address, List<Reception> receptions)
    {
        Id = id;
        Passport = passport;
        Fio = fio;
        BirthDate = birthDate;
        Address = address;
        Receptions = receptions;
    }
    /// <summary>
    /// Redefined comparison function
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>Bool value representing are objects equal or not</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not Patient param)
            return false;
        return Passport == param.Passport && Fio == param.Fio && BirthDate == param.BirthDate &&
            Address == param.Address && Receptions == param.Receptions; //&& ReceptionId == param.ReceptionId;
    }
    /// <summary>
    /// Redefined hash function
    /// </summary>
    /// <returns>Hash code of Id</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
