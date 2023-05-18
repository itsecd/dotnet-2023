using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace RentalService.Client.ViewModels;

public class ClientViewModel : ViewModelBase
{
    private long _id;
    [Required]
    public long Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    
    private string _lastName = String.Empty;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
    
    private string _firstName = String.Empty;
    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    
    private string _patronymic = String.Empty;
    [Required]
    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }
    
    private string _birthDate= String.Empty;
    public string BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }
    
    private string _passport = String.Empty;
    [Required]
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