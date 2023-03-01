namespace PONRF.Classes;

/// <summary>
/// Class Building describes a building 
/// </summary>
public class Building
{
    /// <summary>
    /// RegistNum contains informatiom about registration number of building
    /// </summary>
    public guid RegistNum { get; set; } = guid.Empty;
    /// <summary>
    /// District, street and house number contain informatiom about full address of building
    /// </summary>  
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; } = int.Empty;
    /// <summary>
    /// Area contains informatiom about building area
    /// </summary>
    public int Area { get; set; } = int.Empty;
    /// <summary>
    /// Floors contains informatiom about number of floors of the building
    /// </summary>
    public int Floors { get; set; } = int.Empty;
    /// <summary>
    /// DateOfBuild contains informatiom about date of construction of the building
    /// </summary>
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
    public List<Lot> Lot { get; set; };

    public Building() { }
    public string GetAddress()
    {
        return Combine(District, Street, HouseNumber);
    }

}