﻿namespace ApplicationsServer.DTO;
/// <summary>
/// Employee - a class that describes the characteristics of a worker
/// </summary>
public class EmployeePostDTO
{
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
    public int WorkExperience { set; get; }
    /// <summary>  
    /// Education - shows what kind of education the worker has
    /// </summary>  
    public string Education { set; get; } = "None";
    /// <summary>  
    /// Salary - shows the desired salary
    /// </summary>  
    public int Salary { set; get; }
    /// <summary>  
    /// id - shows the employee's id 
    /// </summary>  
    public int Id { set; get; }

}


