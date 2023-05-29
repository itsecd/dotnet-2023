using Microsoft.Win32.SafeHandles;
using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class RideViewModel : ViewModelBase
{
    [Required] public int Id { get; set; }

    [Required] public string TripDeparturePlace { get; set; } = string.Empty;

    [Required] public string TripDestinationPlace { get; set; } = string.Empty;

    [Required] public DateTime TripDate { get; set; } = DateTime.Now;

    [Required] public double TripTime { get; set; } = 0.0;

    [Required] public double TripPrice { get; set; } = 0.0;

    [Required] public int CarId { get; set; }

    [Required] public int UserId { get; set; }

    public ReactiveCommand<Unit, RideViewModel> OnSubmitCommand { get; set; }

    public RideViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}