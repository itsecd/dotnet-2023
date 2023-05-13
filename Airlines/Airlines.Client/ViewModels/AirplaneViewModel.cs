using ReactiveUI;
using System.Reactive;

namespace Airlines.Client.ViewModels;
public class AirplaneViewModel : ViewModelBase
{

    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _model = string.Empty;
    public string? Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    private int _carryingCapacity;
    public int CarryingCapacity
    {
        get => _carryingCapacity;
        set => this.RaiseAndSetIfChanged(ref _carryingCapacity, value);
    }
    private int _capability;
    public int Capability
    {
        get => _capability;
        set => this.RaiseAndSetIfChanged(ref _capability, value);
    }
    private int _seatingCapacity;
    public int SeatingCapacity
    {
        get => _capability;
        set => this.RaiseAndSetIfChanged(ref _seatingCapacity, value);
    }
    public ReactiveCommand<Unit, AirplaneViewModel> OnSubmitCommand { get; }

    public AirplaneViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

}
