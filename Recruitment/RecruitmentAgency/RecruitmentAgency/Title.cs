namespace RecruitmentAgency;
public class Title
{
    /// <summary>
    /// Section - a string that stores section, for example: IT, Finance, etc...
    /// </summary>  
    public string Section { set; get; } = string.Empty;
    /// <summary>
    /// JobTitle - the string responsible for the title. For example: Programmer, Designer, etc...
    /// </summary>  
    public string JobTitle { set; get; } = string.Empty;
}
