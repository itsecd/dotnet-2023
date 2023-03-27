namespace RentalService.Domain;

/// <summary>
/// class RentalPoint contains all the information about the rental point
/// </summary>
public class RentalPoint
{
    /// <summary>
    /// Id - unique client ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// Title - name of the rental point
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Address - the address where the rental point is located
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
