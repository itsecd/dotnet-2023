using ReactiveUI;
using System.Reactive;

namespace HotelBookingSystem.Desktop.ViewModels;
public class RoomViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _typeOfRoom = string.Empty;
    public string TypeOfRoom
    {
        get => _typeOfRoom;
        set => this.RaiseAndSetIfChanged(ref _typeOfRoom, value);
    }

    private int _numberOfRooms;
    public int NumberOfRooms
    {
        get => _numberOfRooms;
        set => this.RaiseAndSetIfChanged(ref _numberOfRooms, value);
    }

    private int _cost;
    public int Cost
    {
        get => _cost;
        set => this.RaiseAndSetIfChanged(ref _cost, value);
    }

    private int _placementId;
    public int PlacementId
    {
        get => _placementId;
        set => this.RaiseAndSetIfChanged(ref _placementId, value);
    }

    public ReactiveCommand<Unit, RoomViewModel> OkCommand { get; }

    public RoomViewModel()
    {
        OkCommand = ReactiveCommand.Create(() => this);
    }
}