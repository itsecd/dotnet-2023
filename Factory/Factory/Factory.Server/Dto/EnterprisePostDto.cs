namespace Factory.Server.Dto;

public class EnterprisePostDto
{
    public string RegistrationNumber { get; set; } = string.Empty;

    public int TypeID { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string TelephoneNumber { get; set; } = string.Empty;

    public int OwnershipFormID { get; set; } = 0;

    public int EmployeesCount { get; set; } = 0;

    public double TotalArea { get; set; } = 0.0;
}
