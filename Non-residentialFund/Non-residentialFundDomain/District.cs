namespace Non_residentialFundDomain;
public class District
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; } = string.Empty;
    public District(int districtId, string districtName)
    {
        DistrictId = districtId;
        DistrictName = districtName;
    }
}

