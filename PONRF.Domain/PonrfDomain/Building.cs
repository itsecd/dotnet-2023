namespace PonrfDomain;

/// <summary>
/// Class Building describes a building 
/// </summary>
public class Building
{
    /// <summary>
    /// RegistNum contains informatiom about registration number of building
    /// </summary>
    public int RegistNum { get; set; } = int.MinValue;
    /// <summary>
    /// District, street and house number contain informatiom about full address of building
    /// </summary>  
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; } = int.MinValue;
    /// <summary>
    /// Area contains informatiom about building area
    /// </summary>
    public int Area { get; set; } = int.MinValue;
    /// <summary>
    /// Floors contains informatiom about number of floors of the building
    /// </summary>
    public int Floors { get; set; } = int.MinValue;
    /// <summary>
    /// DateOfBuild contains informatiom about date of construction of the building
    /// </summary>
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
    public List<Lot> Lot { get; set; } = new List<Lot>();

    public Building() { }
    public Building(int registNum, string district, string street, int houseNumber, int area, int floors, DateTime dateOfBuild, List<Lot> lot)
    {
        RegistNum = registNum;
        District = district;
        Street = street;
        HouseNumber = houseNumber;
        Area = area;
        Floors = floors;
        DateOfBuild = dateOfBuild;
        Lot = lot;
    }
    public string GetAddress()
    {
        return string.Format("р-н {0}, ул. {1}, {2}", District, Street, HouseNumber);
    }
}