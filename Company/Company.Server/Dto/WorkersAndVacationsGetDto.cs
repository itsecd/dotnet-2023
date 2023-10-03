namespace Company.Server.Dto;

/// <summary>
/// WorkersAndVacationsGetDto - narrows the WorkersAndVacations class for Get method in controller
/// </summary>
public class WorkersAndVacationsGetDto
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    public int WorkerId { get; set; }


    /// <summary>
    /// VacationId - an id of Vacation object
    /// </summary>
    public int VacationId { get; set; }
}
