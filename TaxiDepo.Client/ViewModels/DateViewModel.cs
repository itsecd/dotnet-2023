using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class DateViewModel : ViewModelBase
{
    [Required] public DateTime DateBefore { get; set; } = DateTime.Now;

    [Required] public DateTime DateAfter { get; set; } = DateTime.Now;

    public ReactiveCommand<Unit, DateViewModel> OnSubmitCommand { get; set; }

    public DateViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}