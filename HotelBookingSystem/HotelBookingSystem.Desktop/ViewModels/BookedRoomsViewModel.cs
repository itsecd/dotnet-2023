using ReactiveUI;
using System;
using System.Reactive;

namespace HotelBookingSystem.Desktop.ViewModels;
public class BookedRoomsViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _clientId;
    public int ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }

    private int _bookedRoomId;
    public int BookedRoomId
    {
        get => _bookedRoomId;
        set => this.RaiseAndSetIfChanged(ref _bookedRoomId, value);
    }

    private DateTimeOffset _entryDate;
    public DateTimeOffset EntryDate
    {
        get => _entryDate;
        set => this.RaiseAndSetIfChanged(ref _entryDate, value);
    }

    private DateTimeOffset _bookingTerm;
    public DateTimeOffset BookingTerm
    {
        get => _bookingTerm;
        set => this.RaiseAndSetIfChanged(ref _bookingTerm, value);
    }

    private DateTimeOffset _departmentDate;
    public DateTimeOffset DepartmentDate
    {
        get => _departmentDate;
        set => this.RaiseAndSetIfChanged(ref _departmentDate, value);
    }

    public ReactiveCommand<Unit, BookedRoomsViewModel> OkCommand { get; }

    public BookedRoomsViewModel()
    {
        OkCommand = ReactiveCommand.Create(() => this);
    }
}
