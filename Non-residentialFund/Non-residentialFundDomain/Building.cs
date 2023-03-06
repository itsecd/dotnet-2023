namespace Non_residentialFundDomain;
public class Building
{
    public int RegistrationNumber { get; set; }
    public string Address { get; set; } = string.Empty;
    public int DistrictId { get; set; } = 0;
    public double Area { get; set; } = 0.0;
    public int FloorCount { get; set; } = 1;
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
