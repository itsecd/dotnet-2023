namespace ApplicationsServer.DTO;
/// <summary>
/// Title - a class that describes the field of work and position
/// </summary>
public class TitleGetDTO
{
    /// <summary>
    /// Section - a string that stores section, for example: IT, Finance, etc...
    /// </summary>  
    public string? Section { set; get; }
    /// <summary>
    /// JobTitle - the string responsible for the title. For example: Programmer, Designer, etc...
    /// </summary>  
    public string? JobTitle { set; get; }
    /// <summary>  
    /// id - shows the title's
    /// </summary>  
    public int Id { set; get; }
}
