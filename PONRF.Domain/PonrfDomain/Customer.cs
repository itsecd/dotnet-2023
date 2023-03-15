namespace PonrfDomain;

/// <summary>
/// Class Customer describes a customer
/// </summary>
public class Customer
{
    /// <summary>
    /// Id is an identifier of customer
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Passport contains information about passport's number of customer
    /// </summary>
    public string Passport { get; set; } = string.Empty;
    /// <summary>
    /// FIO contains information about full name of customer
    /// </summary>  
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// Address contains information about home address of customer
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public Customer() { }
    public Customer(int id, string passport, string fio, string address)
    {
        Id = id;
        Passport = passport;
        Fio = fio;
        Address = address;
    }
}