using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;
public class TopAuctionViewModel : ViewModelBase
{
    private string _organizer = string.Empty;
    [Required]
    public string Organizer
    {
        get => _organizer;
        set => this.RaiseAndSetIfChanged(ref _organizer, value);
    }

    private int _profit;
    [Required]
    public int Profit
    {
        get => _profit;
        set => this.RaiseAndSetIfChanged(ref _profit, value);
    }

    public ReactiveCommand<Unit, TopAuctionViewModel> OnSubmitCommand { get; }
    public TopAuctionViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
