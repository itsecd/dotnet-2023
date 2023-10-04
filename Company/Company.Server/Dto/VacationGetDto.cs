namespace Company.Server.Dto;

/// <summary>
/// VacationGetDto - narrows the Vacation class for Get method in controller
/// </summary>
public class VacationGetDto
{
    /// <summary>
    /// Id - an id of the Vacation
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Id - an id of the VacationSpot
    /// </summary>
    public int VacationSpotId { get; set; }


    /// <summary>
    /// IssueDate - a date of the issue
    /// </summary>
    public DateTime IssueDate { get; set; } = DateTime.MinValue;
}
