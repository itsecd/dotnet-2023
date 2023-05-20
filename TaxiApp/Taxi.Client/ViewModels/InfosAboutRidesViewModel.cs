using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;

namespace Taxi.Client.ViewModels;

public class InfosAboutRidesViewModel: ViewModelBase
{
    [Required] 
    [Reactive] 
    public string FirstName { get; set; } = string.Empty;

    [Required] 
    [Reactive] 
    public string LastName { get; set; } = string.Empty;

    
    [Reactive] 
    public string? Patronymic { get; set; }
    
    [Required] 
    [Reactive] 
    public int Count { get; set; }
    
    [Required] 
    [Reactive] 
    public string AverageTime { get; set; } = string.Empty;
    
    [Required] 
    [Reactive] 
    public string MaxTime { get; set; } = string.Empty;
}