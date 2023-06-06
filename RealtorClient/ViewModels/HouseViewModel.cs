using ReactiveUI;
using System.Reactive;

namespace RealtorClient.ViewModels;
public class HouseViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _type;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }

    private string _address;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private int _square;
    public int Square
    {
        get => _square;
        set => this.RaiseAndSetIfChanged(ref _square, value);
    }

    private int _rooms;
    public int Rooms
    {
        get => _rooms;
        set => this.RaiseAndSetIfChanged(ref _rooms, value);
    }
    public ReactiveCommand<Unit, HouseViewModel> OnSubmitCommand { get; }

    public HouseViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
