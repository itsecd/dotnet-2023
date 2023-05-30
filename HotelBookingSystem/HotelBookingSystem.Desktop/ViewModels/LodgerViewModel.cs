using ReactiveUI;
using System;
using System.Reactive;

namespace HotelBookingSystem.Desktop.ViewModels;
public class LodgerViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _passport;
    public int Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private DateTimeOffset _birthdate;
    public DateTimeOffset Birthdate
    {
        get => _birthdate;
        set => this.RaiseAndSetIfChanged(ref _birthdate, value);
    }

    public ReactiveCommand<Unit, LodgerViewModel> OkCommand { get; }

    public LodgerViewModel()
    {
        OkCommand = ReactiveCommand.Create(() => this);
    }
}
