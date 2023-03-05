using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecruitmentAgency;
public class Company {
    /// <summary>
    /// CompanyName - a string that stores the company name
    /// </summary>  
    public string CompanyName { set; get; } = string.Empty;
    /// <summary>
    /// ContactName - the string responsible for the name of the company representative
    /// </summary>  
    public string ContactName { set; get; } = string.Empty;
    /// <summary>
    /// Telephone - a string that stores the phone number
    /// </summary>
    public string Telephone { set; get; } = string.Empty;
}
