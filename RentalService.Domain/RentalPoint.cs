namespace RentalService.Domain;

/// <summary>
///     class RentalPoint contains all the information about the rental point
/// </summary>
public class RentalPoint
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Title - name of the rental point
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Address - the address where the rental point is located
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    ///     RentalInformations - information about all leases at this point
    /// </summary>
    public List<RentalInformation> RentalInformations { get; set; } = new();

    /// <summary>
    ///     RefundInformations - information about all returns to this point
    /// </summary>
    public List<RefundInformation> RefundInformations { get; set; } = new();
}