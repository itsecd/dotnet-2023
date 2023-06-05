using System;
using ReactiveUI;
using System.Reactive;
using System.ComponentModel.DataAnnotations;

namespace TransportManagment.Client.ViewModels;
public class TopDriversViewModel : ViewModelBase
{
    private string _firstName = string.Empty;
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    private string _lastName = string.Empty;
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
    private string _patronymic = string.Empty;
    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }
    private int _passport;
    public int Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }
    private int _driverCard;
    public int DriverCard
    {
        get => _driverCard;
        set => this.RaiseAndSetIfChanged(ref _driverCard, value);
    }
    private int _number;
    public int Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }
    private int _count = 0;
    public int Count 
    {
        get => _count;
        set => this.RaiseAndSetIfChanged(ref _count, value);
    }
    public ReactiveCommand<Unit, TopDriversViewModel> OnSubmitCommand { get; }
    public TopDriversViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}