using System;
using System.ComponentModel.DataAnnotations;

namespace TaxiDepo.Client.ViewModels;

public class CountUserRidesViewModel : ViewModelBase
{
    [Required] public string UserSurname { get; set; } = string.Empty;

    [Required] public string UserName { get; set; } = string.Empty;

    [Required] public string UserPatronymic { get; set; } = string.Empty;

    [Required] public string UserPhoneNumber { get; set; } = string.Empty;

    [Required] public int AmountRides { get; set; } = 0;

    [Required] public DateTime UserDate { get; set; }
}