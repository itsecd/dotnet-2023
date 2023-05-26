using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class PrivatizedBuildingViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private DateTimeOffset _dateOfSale = DateTime.Now;
    public DateTimeOffset DateOfSale
    {
        get => _dateOfSale;
        set => this.RaiseAndSetIfChanged(ref _dateOfSale, value);
    }

    private int _firstCost;
    [Required]
    public int FirstCost
    {
        get => _firstCost;
        set => this.RaiseAndSetIfChanged(ref _firstCost, value);
    }

    private int _secondCost;
    public int SecondCost
    {
        get => _secondCost;
        set => this.RaiseAndSetIfChanged(ref _secondCost, value);
    }

    private int? _customerId = null;
    public int? CustomerId
    {
        get => _customerId;
        set => this.RaiseAndSetIfChanged(ref _customerId, value);
    }

    private int _auctionId;
    [Required]
    public int AuctionId
    {
        get => _auctionId;
        set => this.RaiseAndSetIfChanged(ref _auctionId, value);
    }

    private int _buildingId;
    [Required]
    public int BuildingId
    {
        get => _buildingId;
        set => this.RaiseAndSetIfChanged(ref _buildingId, value);
    }

    public ReactiveCommand<Unit, PrivatizedBuildingViewModel> OnSubmitCommand { get; }
    public PrivatizedBuildingViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
