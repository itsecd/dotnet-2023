using ReactiveUI;

namespace TransportMgmt.Client.ViewModels;

public class RoutesViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _routeNumber = string.Empty;

    public string RouteNumber
    {
        get => _routeNumber;
        set => this.RaiseAndSetIfChanged(ref _routeNumber, value);
    }

}
