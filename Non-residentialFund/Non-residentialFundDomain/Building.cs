namespace Non_residentialFundDomain;
/// <summary>
/// Building - a class that describes characteristics of a building
/// </summary>
public class Building
{
    /// <summary>
    /// RegistrationNumber - registration number of building
    /// </summary>
    public int RegistrationNumber { get; set; }
    /// <summary>
    /// Address - a string that store address of building
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// DistrictId - id of the district in which the building is located
    /// </summary>
    public int DistrictId { get; set; } = 0;
    /// <summary>
    /// Area - Building area
    /// </summary>
    public double Area { get; set; } = 0.0;
    /// <summary>
    /// FloorCount - count of floors in building
    /// </summary>
    public int FloorCount { get; set; } = 1;
    /// <summary>
    /// BuildDate - date of building construction
    /// </summary>
    public DateOnly BuildDate { get; set; } = new DateOnly();

    public Building(int regNum, string address, int districtId, double area, int flourCount, DateOnly buildDate)
    {
        RegistrationNumber = regNum;
        Address = address;
        DistrictId = districtId;
        Area = area;
        FloorCount = flourCount;
        BuildDate = buildDate;
    }
}
