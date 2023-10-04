namespace Company.Server.Dto;

/// <summary>
/// VacationPostDto - narrows the Vacation class for Post method in controller
/// </summary>
public class VacationPostDto
{
    /// <summary>
    /// Id - an id of the VacationSpot
    /// </summary>
    public int VacationSpotId { get; set; }


    /// <summary>
    /// IssueDate - a date of the issue
    /// </summary>
    public DateTime IssueDate { get; set; } = DateTime.MinValue;
}
