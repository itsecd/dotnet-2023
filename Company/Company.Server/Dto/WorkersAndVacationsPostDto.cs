namespace Company.Server.Dto;

/// <summary>
/// WorkersAndVacationsPostDto - narrows the WorkersAndVacations class for Post method in controller
/// </summary>
public class WorkersAndVacationsPostDto
{
    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    public int WorkerId { get; set; }


    /// <summary>
    /// VacationId - an id of Vacation object
    /// </summary>
    public int VacationId { get; set; }
}
