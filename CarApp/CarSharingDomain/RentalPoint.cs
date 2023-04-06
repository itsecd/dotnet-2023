namespace CarSharingDomain;
/// <summary>
/// this class describes rental point where client can rent a car
/// </summary>
public class RentalPoint
{
    /// <summary>
    /// name of the rental point
    /// </summary>
    public string PointName { get; set; } = string.Empty;
    /// <summary>
    /// address of the rental point
    /// </summary>
    public string PointAddress { get; set; } = string.Empty;
    /// <summary>
    /// id of the rental point
    /// </summary>
    public uint PointId { get; set; }
    /// <summary>
    /// Default constructor
    /// </summary>
    public RentalPoint() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="pointId"></param>
    /// <param name="pointName"></param>
    /// <param name="pointAddress"></param>
    public RentalPoint(uint pointId, string pointName, string pointAddress)
    {
        PointId = pointId;
        PointName = pointName;
        PointAddress = pointAddress;
    }
}
