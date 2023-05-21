using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AirplaneBookingSystem.Client.ViewModels;
public class ClientViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _passportNumber = string.Empty;
    [Required]
    public string PassportNumber
    {
        get => _passportNumber;
        set => this.RaiseAndSetIfChanged(ref _passportNumber, value);
    }
    private DateTimeOffset _birthdayData = DateTime.Today;
    [Required]
    public DateTimeOffset BirthdayData
    {
        get => _birthdayData;
        set => this.RaiseAndSetIfChanged(ref _birthdayData, value);
    }
    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public ReactiveCommand<Unit, ClientViewModel> OnSubmitCommand { get; }
    public ClientViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}