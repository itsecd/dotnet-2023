using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentAgency;
public class CompanyApplication{
    /// <summary>
    /// Company - contains information about the company
    /// </summary>  
    public Company Company { get; set; } = new();
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; } = DateTime.MinValue;
    /// <summary>
    /// WorkExperience - shows the required work experience in years
    /// </summary>
    public int WorkExperience { set; get; } = 0;
    /// <summary>
    /// Salary - shows the wages which the company will pay
    /// </summary>
    public int Salary { set; get; } = 0;
    /// <summary>
    /// Title - shows the wages which the company will pay
    /// </summary>
    public Title Title{ set; get; } = new();
}
