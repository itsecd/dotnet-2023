namespace PonrfDomain;

/// <summary>
/// Class Customer describes a customer
/// </summary>
public class Customer
{
    /// <summary>
    /// Passport contains informatiom about passport's number of customer
    /// </summary>
    public Guid Passport { get; set; } = Guid.Empty;
    /// <summary>
    /// FIO contains informatiom about full name of customer
    /// </summary>  
    public string FIO { get; set; } = string.Empty;
    /// <summary>
    /// Address contains informatiom about home address of customer
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public Customer() { }
}