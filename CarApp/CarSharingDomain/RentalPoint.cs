using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharingDomain;
/// <summary>
/// this class describes rental point where client can rent a car
/// </summary>
public class RentalPoint
{
    /// <summary>
    /// name of the rental point
    /// </summary>
    [Column("name")]
    public string PointName { get; set; } = string.Empty;
    /// <summary>
    /// address of the rental point
    /// </summary>
    [Column("address")]
    public string PointAddress { get; set; } = string.Empty;
    /// <summary>
    /// id of the rental point
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Default constructor
    /// </summary>
    public RentalPoint() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pointName"></param>
    /// <param name="pointAddress"></param>
    public RentalPoint(int id, string pointName, string pointAddress)
    {
        Id = id;
        PointName = pointName;
        PointAddress = pointAddress;
    }
}
