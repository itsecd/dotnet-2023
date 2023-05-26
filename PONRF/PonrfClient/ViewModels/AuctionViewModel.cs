using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class AuctionViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

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

    public ReactiveCommand<Unit, AuctionViewModel> OnSubmitCommand { get; }
    public AuctionViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
