namespace PonrfDomain;

/// <summary>
/// Class Building describes a building 
/// </summary>
public class Building
{
    /// <summary>
    /// RegistNum contains information about registration number of building
    /// </summary>
    public int RegistNum { get; set; }
    /// <summary>
    /// District, street and house number contain information about full address of building
    /// </summary>  
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; } = int.MinValue;
    /// <summary>
    /// Area contains information about building area
    /// </summary>
    public int Area { get; set; } = int.MinValue;
    /// <summary>
    /// Floors contains information about number of floors of the building
    /// </summary>
    public int Floors { get; set; } = int.MinValue;
    /// <summary>
    /// DateOfBuild contains information about date of construction of the building
    /// </summary>
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
    public List<PrivatizedBuilding> PrivatizedBuilding { get; set; } = new List<PrivatizedBuilding>();

    public Building() { }
    public Building(int registNum, string district, string street, int houseNumber, int area, int floors, DateTime dateOfBuild, List<PrivatizedBuilding> privatizedBuilding)
    {
        RegistNum = registNum;
        District = district;
        Street = street;
        HouseNumber = houseNumber;
        Area = area;
        Floors = floors;
        DateOfBuild = dateOfBuild;
        PrivatizedBuilding = privatizedBuilding;
    }
    public string GetAddress()
    {
        return $"р-н {District}, ул. {Street}, {HouseNumber}";
    }
}