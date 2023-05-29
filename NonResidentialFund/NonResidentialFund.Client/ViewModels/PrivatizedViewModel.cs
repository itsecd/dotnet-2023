using ReactiveUI;
using System;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class PrivatizedViewModel : ViewModelBase
{
    private int _registrationNumber;

    public int RegistrationNumber
    {
        get => _registrationNumber;
        set => this.RaiseAndSetIfChanged(ref _registrationNumber, value);
    }
    private int _buyerId;
    public int BuyerId
    {
        get => _buyerId;
        set => this.RaiseAndSetIfChanged(ref _buyerId, value);
    }
    private int _auctionId;
    public int AuctionId
    {
        get => _auctionId;
        set => this.RaiseAndSetIfChanged(ref _auctionId, value);
    }
    private DateTimeOffset _saleDate = DateTimeOffset.Now;
    public DateTimeOffset SaleDate
    {
        get => _saleDate;
        set => this.RaiseAndSetIfChanged(ref _saleDate, value);
    }

    private double _startPrice;
    public double StartPrice
    {
        get => _startPrice;
        set => this.RaiseAndSetIfChanged(ref _startPrice, value);
    }
    private double _endPrice;
    public double EndPrice
    {
        get => _endPrice;
        set => this.RaiseAndSetIfChanged(ref _endPrice, value);
    }

    public ReactiveCommand<Unit, PrivatizedViewModel> OnSubmitCommand { get; }

    public PrivatizedViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
