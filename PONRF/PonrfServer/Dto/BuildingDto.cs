using PonrfDomain;

namespace PonrfServer.Dto;

public class BuildingDto
{
    public int Id { get; set; }
    public string RegistNum { get; set; } = string.Empty;

    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
    public int Area { get; set; }
    public int Floors { get; set; }
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
}