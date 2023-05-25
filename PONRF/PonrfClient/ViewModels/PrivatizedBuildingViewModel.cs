using ReactiveUI;
using System;
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

    private int _firstCost;
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

    public DateTimeOffset _dateOfSale;
    public DateTimeOffset DateOfSale
    {
        get => _dateOfSale;
        set => this.RaiseAndSetIfChanged(ref _dateOfSale, value);
    }

    public ReactiveCommand<Unit, PrivatizedBuildingViewModel> OnSubmitCommand { get; }
    public PrivatizedBuildingViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
