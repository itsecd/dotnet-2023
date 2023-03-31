namespace RentalService.Server.Dto;

public class RentalPointGetDto
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
}