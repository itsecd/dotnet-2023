using ReactiveUI;
using System;

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
    public int FabricId
    {
        get => _fabricId;
        set => this.RaiseAndSetIfChanged(ref _fabricId, value);
    }

    private int _providerId;
    public int ProviderId
    {
        get => _providerId;
        set => this.RaiseAndSetIfChanged(ref _providerId, value);
    }

    private DateTime _date;
    public DateTime Date
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
}
