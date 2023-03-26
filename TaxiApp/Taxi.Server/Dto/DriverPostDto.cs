namespace Taxi.Server.Dto;

public class DriverPostDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public string Passport { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
}