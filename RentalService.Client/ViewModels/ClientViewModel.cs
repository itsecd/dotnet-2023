using System;
using System.Reactive;
using ReactiveUI;

namespace RentalService.Client.ViewModels;

public class ClientViewModel : ViewModelBase
{
    private ulong _id;
    public ulong Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    
    private string _lastName = String.Empty;
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
    
    private string _firstName = String.Empty;
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    
    private string _patronymic = String.Empty;
    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }
    
    /*private DateTime _birthDate = DateTime.MinValue;
    public DateTime BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }*/
    
    private string _passport = String.Empty;
    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }
    
    public ReactiveCommand<Unit, ClientViewModel> OkButtonOnClick { get; }

    public ClientViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    
}