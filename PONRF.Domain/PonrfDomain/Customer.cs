namespace PonrfDomain;

/// <summary>
/// Class Customer describes a customer
/// </summary>
public class Customer
{
    /// <summary>
    /// Passport contains information about passport's number of customer
    /// </summary>
    public int Passport { get; set; }
    /// <summary>
    /// FIO contains information about full name of customer
    /// </summary>  
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// Address contains information about home address of customer
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public Customer() { }
    public Customer(int passport, string fio, string address)
    {
        Passport = passport;
        Fio = fio;
        Address = address;
    }
}