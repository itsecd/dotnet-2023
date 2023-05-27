using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System;

namespace PonrfClient.ViewModels;
internal class AuctionsWithoutFullSalesViewModel : ViewModelBase
{
    private int _auctionId;
    public int AuctionId
    {
        get => _auctionId;
        set => this.RaiseAndSetIfChanged(ref _auctionId, value);
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

    public ReactiveCommand<Unit, AuctionsWithoutFullSalesViewModel> OnSubmitCommand { get; }
    public AuctionsWithoutFullSalesViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}