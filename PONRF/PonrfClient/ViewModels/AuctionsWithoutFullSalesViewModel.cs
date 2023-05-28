using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;
public class AuctionsWithoutFullSalesViewModel : ViewModelBase
{
    private DateTimeOffset _date = DateTime.Now;
    [Required]
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private string _organizer = string.Empty;
    [Required]
    public string Organizer
    {
        get => _organizer;
        set => this.RaiseAndSetIfChanged(ref _organizer, value);
    }

    public ReactiveCommand<Unit, AuctionsWithoutFullSalesViewModel> OnSubmitCommand { get; }
    public AuctionsWithoutFullSalesViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}