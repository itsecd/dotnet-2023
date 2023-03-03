namespace Polyclinic.Domain;
public class Patient
{
    public int PassportNumber { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;
    public DateOnly DateBirth { get; set; } = new DateOnly();
    public string Address { get; set; } = string.Empty;
    public int Id { get; set; } = 0;
    public Patient(int passportNumber, string fullName, DateOnly dateBirth, string address, int id)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        DateBirth = dateBirth;
        Address = address;
        Id = id;
    }
}
