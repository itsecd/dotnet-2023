using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class AuctionViewModel : ViewModelBase
{
    private int _auctionId;

    public int AuctionId
    {
        get => _auctionId;
        set => this.RaiseAndSetIfChanged(ref _auctionId, value);
    }

    private DateTimeOffset _date = DateTimeOffset.Now;
    [Required]
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private int _organizationId;
    [Required]
    public int OrganizationId
    {
        get => _organizationId;
        set => this.RaiseAndSetIfChanged(ref _organizationId, value);
    }

    public ReactiveCommand<Unit, AuctionViewModel> OnSubmitCommand { get; }

    public AuctionViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
