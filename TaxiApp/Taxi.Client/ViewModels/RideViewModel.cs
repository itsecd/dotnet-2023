using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class RideViewModel
{
    [Reactive] 
    public ulong Id { get; set; }
    
    [Required] 
    [Reactive] 
    public string DeparturePoint { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public string DestinationPoint { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public DateTime RideDate { get; set; }
    
    [Required] 
    [Reactive] 
    public TimeSpan RideTime { get; set; }
    
    [Required] 
    [Reactive] 
    public uint Cost { get; set; } = 0;
    
    [Required] 
    [Reactive] 
    public ulong PassengerId { get; set; }
    
    [Required] 
    [Reactive] 
    public ulong VehicleId { get; set; }
    
    
    public ReactiveCommand<Unit, RideViewModel> OnSubmitCommand { get; }

    public RideViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
    
}