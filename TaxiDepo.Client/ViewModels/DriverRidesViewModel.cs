using System.ComponentModel.DataAnnotations;

namespace TaxiDepo.Client.ViewModels;

public class DriverRidesViewModel : ViewModelBase
{
    [Required] public string DriverSurname { get; set; } = string.Empty;

    [Required] public string DriverName { get; set; } = string.Empty;

    [Required] public string DriverPatronymic { get; set; } = string.Empty;

    [Required] public int AmountRides { get; set; } = 0;

    [Required] public double AverageTime { get; set; } = 0.0;

    [Required] public double MaxTime { get; set; } = 0.0;
}