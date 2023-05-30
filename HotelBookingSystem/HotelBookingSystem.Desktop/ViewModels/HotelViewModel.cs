using ReactiveUI;
using System.Reactive;

namespace HotelBookingSystem.Desktop.ViewModels;
public class HotelViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _city = string.Empty;
    public string City
    {
        get => _city;
        set => this.RaiseAndSetIfChanged(ref _city, value);
    }

    private string _adress = string.Empty;
    public string Adress
    {
        get => _adress;
        set => this.RaiseAndSetIfChanged(ref _adress, value);
    }

    public ReactiveCommand<Unit, HotelViewModel> OkCommand { get; }

    public HotelViewModel()
    {
        OkCommand = ReactiveCommand.Create(() => this);
    }
}
