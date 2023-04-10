namespace PonrfDomain;

/// <summary>
/// Class Building describes a building 
/// </summary>
public class Building
{
    /// <summary>
    /// Id is an identifier of building
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// RegistNum contains information about registration number of building
    /// </summary>
    public string RegistNum { get; set; } = string.Empty;
    /// <summary>
    /// District contains information about district where the building is located
    /// </summary> 
    public string District { get; set; } = string.Empty;
    /// <summary>
    /// Street contains information about street where the building is located
    /// </summary>
    public string Street { get; set; } = string.Empty;
    /// <summary>
    /// HouseNumber contains information about house number of building
    /// </summary>
    public int HouseNumber { get; set; }
    /// <summary>
    /// Area contains information about building area
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// Floors contains information about number of floors of the building
    /// </summary>
    public int Floors { get; set; }
    /// <summary>
    /// DateOfBuild contains information about date of construction of the building
    /// </summary>
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
    /// <summary>
    /// List of all privatized buildings (if the building is up for auction)
    /// </summary>
    public List<PrivatizedBuilding>? PrivatizedBuilding { get; set; }
    /// <summary>
    /// Constructor for Building
    /// </summary>
    public Building() { }
    /// <summary>
    /// Constructor for Building with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="registNum"></param>
    /// <param name="district"></param>
    /// <param name="street"></param>
    /// <param name="houseNumber"></param>
    /// <param name="area"></param>
    /// <param name="floors"></param>
    /// <param name="dateOfBuild"></param>
    /// <param name="privatizedBuilding"></param>
    public Building(int id, string registNum, string district, string street, int houseNumber, int area, int floors, DateTime dateOfBuild, List<PrivatizedBuilding> privatizedBuilding)
    {
        Id = id;
        RegistNum = registNum;
        District = district;
        Street = street;
        HouseNumber = houseNumber;
        Area = area;
        Floors = floors;
        DateOfBuild = dateOfBuild;
        PrivatizedBuilding = privatizedBuilding;
    }
    /// <summary>
    /// GetAddress used for getting full address of the building
    /// </summary>
    /// <returns>Address</returns>
    public string GetAddress()
    {
        return $"р-н {District}, ул. {Street}, {HouseNumber}";
    }
}
