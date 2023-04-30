using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency;
/// <summary>
/// Company - a class that describes the company application
/// </summary>
public class CompanyApplication
{
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
    /// Education - shows the education level
    /// </summary>
    public string Education { set; get; } = string.Empty;
    /// <summary>  
    /// id - shows the company's application id
    /// </summary>  
    [Key]
    public int Id { set; get; }
    /// <summary>
    /// Company - contains information about the company
    /// </summary>
    [ForeignKey("CompanyId")]
    public int? CompanyId { get; set; }
    /// <summary>
    /// Title - shows the job id
    /// </summary>
    [ForeignKey("TitleId")]
    public int? TitleId { set; get; }
}