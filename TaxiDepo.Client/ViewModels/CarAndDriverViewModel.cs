using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace TaxiDepo.Client.ViewModels;

public class CarAndDriverViewModel : ViewModelBase
{
    [Required] public string CarColor { get; set; } = string.Empty;

    [Required] public string CarNumber { get; set; } = string.Empty;

    [Required] public string CarModel { get; set; } = string.Empty;

    [Required] public int DriverId { get; set; }

    [Required] public string DriverSurname { get; set; } = string.Empty;

    [Required] public string DriverName { get; set; } = string.Empty;

    [Required] public string DriverPatronymic { get; set; } = string.Empty;

    [Required] public string DriverPassportId { get; set; } = string.Empty;

    [Required] public string DriverPhoneNumber { get; set; } = string.Empty;

    [Required] public string DriverAddress { get; set; } = string.Empty;

    public ReactiveCommand<Unit, CarAndDriverViewModel> OnSubmitCommand { get; }

    public CarAndDriverViewModel(int id)
    { 
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}