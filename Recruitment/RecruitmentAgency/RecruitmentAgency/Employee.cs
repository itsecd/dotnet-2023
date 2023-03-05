namespace RecruitmentAgency;
/// <summary>
/// Employee - a class that describes the characteristics of a worker
/// </summary>
public class Employee{
    /// <summary>
    /// PersonalName - a string for name, second_name and surname
    /// </summary>  
    public string PersonalName { set; get; } = string.Empty;
    /// <summary>
    /// Telephone - a string that stores the phone number
    /// </summary>
    public string Telephone { set; get; } = string.Empty;
    /// <summary>
    /// WorkExperience - shows the number of years a person has worked
    /// </summary>  
    public int WorkExperience { set; get; } = 0;
    /// </summary>  
    /// Education - shows what kind of education the worker has
    /// </summary>  
    public string Education { set; get; } = "None";
    /// </summary>  
    /// Salary - shows the desired salary
    /// </summary>  
    public int Salary { set; get; } = 0;

}
