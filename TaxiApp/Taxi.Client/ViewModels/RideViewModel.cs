using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class RideViewModel
{
    public RideViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

    [Reactive] public ulong Id { get; set; }

    [Required] [Reactive] public string DeparturePoint { get; set; } = string.Empty;

    [Required] [Reactive] public string DestinationPoint { get; set; } = string.Empty;

    [Required] [Reactive] public DateTimeOffset RideDate { get; set; } = DateTime.Today;

    [Required] [Reactive] public string RideTime { get; set; }

    [Required] [Reactive] public uint Cost { get; set; } = 0;

    [Required] [Reactive] public ulong PassengerId { get; set; }

    [Required] [Reactive] public ulong VehicleId { get; set; }


    public ReactiveCommand<Unit, RideViewModel> OnSubmitCommand { get; }
}