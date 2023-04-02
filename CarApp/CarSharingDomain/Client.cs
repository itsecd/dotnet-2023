namespace CarSharingDomain;
/// <summary>
/// describes a person who rented a car 
/// </summary>
public class Client
{
    /// <summary>
    /// client's passport number
    /// </summary>
    public string Passport { set; get; } = string.Empty;
    /// <summary>
    /// client's birthday date
    /// </summary>
    public DateTime BirthDate { set; get; } = DateTime.MinValue;
    /// <summary>
    /// client's fist name
    /// </summary>
    public string FirstName { set; get; } = string.Empty;
    /// <summary>
    /// client's last name
    /// </summary>
    public string LastName { set; get; } = string.Empty;
    /// <summary>
    /// client's id
    /// </summary>
    public uint Uid { set; get; }
    public Client() { }
    public Client(uint uid, string passport, DateTime birthDate, string firstName, string lastName)
    {
        Uid = uid;
        Passport = passport;
        BirthDate = birthDate;
        FirstName = firstName;
        LastName = lastName;
    }
}