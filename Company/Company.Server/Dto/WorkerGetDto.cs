namespace Company.Server.Dto;

/// <summary>
/// WorkerGetDto - narrows the Worker class for Get method in controller
/// </summary>
public class WorkerGetDto
{
    /// <summary>
    /// Id - Identificator for each Worker
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// RegistrationNumber - registration number of a Worker
    /// </summary>
    public int RegistrationNumber { get; set; }


    /// <summary>
    /// LastName - last name of a Worker
    /// </summary>
    public string LastName { get; set; } = string.Empty;


    /// <summary>
    /// FirstName - first name of a Worker
    /// </summary>
    public string FirstName { get; set; } = string.Empty;


    /// <summary>
    /// LastName - patronymic name of a Worker
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;


    /// <summary>
    /// BirthDate - birth date of a Worker
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;


    /// <summary>
    /// Sex - sex of a Worker (ex. "male", "female")
    /// </summary>
    public string Sex { get; set; } = string.Empty;


    /// <summary>
    /// WorkshopId - an id of the Workshop
    /// </summary>
    public int WorkshopId { get; set; }


    /// <summary>
    /// HomeAddress - home address of a Worker
    /// </summary>
    public string HomeAddress { get; set; } = string.Empty;


    /// <summary>
    /// HomeTelephone - home telephone of a Worker
    /// </summary>
    public string HomeTelephone { get; set; } = string.Empty;


    /// <summary>
    /// WorkTelephone - work telephone of a Worker
    /// </summary>
    public string WorkTelephone { get; set; } = string.Empty;


    /// <summary>
    /// MaritalStatus - family status of a Worker (ex. "married", "single")
    /// </summary>
    public string MaritalStatus { get; set; } = string.Empty;


    /// <summary>
    /// PeopleInFamily - number of people in the Worker's family
    /// </summary>
    public int PeopleInFamily { get; set; } = 1;


    /// <summary>
    /// ChildrenInFamily - number of the Worker's children
    /// </summary>
    public int ChildrenInFamily { get; set; } = 0;
}
