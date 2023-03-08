﻿namespace RecruitmentAgency;
/// <summary>
/// Company - a class that describes the company application, it 
/// </summary>
public class CompanyApplication
{
    /// <summary>
    /// Company - contains information about the company
    /// </summary>  
    public Company? Company { get; set; }
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// WorkExperience - shows the required work experience in years
    /// </summary>
    public int WorkExperience { set; get; }
    /// <summary>
    /// Salary - shows the wages which the company will pay
    /// </summary>
    public int Salary { set; get; }
    /// <summary>
    /// Title - shows the wages which the company will pay
    /// </summary>
    public Title? Title { set; get; }
    /// <summary>
    /// Education - shows the education level
    /// </summary>
    public string Education { set; get; } = string.Empty;
    /// <summary>  
    /// id - shows the company's application id
    /// </summary>  
    public int Id { set; get; }
}
