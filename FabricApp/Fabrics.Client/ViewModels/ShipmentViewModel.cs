using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Fabrics.Client.ViewModels;
public class ShipmentViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _fabricId;

    [Required]
    public int FabricId
    {
        get => _fabricId;
        set => this.RaiseAndSetIfChanged(ref _fabricId, value);
    }

    private int _providerId;
    [Required]
    public int ProviderId
    {
        get => _providerId;
        set => this.RaiseAndSetIfChanged(ref _providerId, value);
    }

    private DateTimeOffset _date;
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private int _numberOfGoods;
    public int NumberOfGoods
    {
        get => _numberOfGoods;
        set => this.RaiseAndSetIfChanged(ref _numberOfGoods, value);
    }

    public ReactiveCommand<Unit, ShipmentViewModel> OnSubmitCommand { get; }

    public ShipmentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
