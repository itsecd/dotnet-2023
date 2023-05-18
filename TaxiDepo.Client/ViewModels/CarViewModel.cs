using ReactiveUI;
using System.Reactive;

namespace TaxiDepo.Client.ViewModels;

public class CarViewModel : ViewModelBase
{
    private int _id;
    
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _carModel = string.Empty;

    public string CarModel
    {
        get => _carModel;
        set => this.RaiseAndSetIfChanged(ref _carModel, value);
    }

    private string _carNumber = string.Empty;

    public string CarNumber
    {
        get => _carNumber;
        set => this.RaiseAndSetIfChanged(ref _carNumber, value);
    }

    private string _carColor = string.Empty;

    public string CarColor
    {
        get => _carColor;
        set => this.RaiseAndSetIfChanged(ref _carColor, value);
    }

    private int _driverId;

    public int DriverId
    {
        get => _driverId;
        set => this.RaiseAndSetIfChanged(ref _driverId, value);
    }

    public ReactiveCommand<Unit, CarViewModel> OnSubmitCommand { get; set; }

    public CarViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}