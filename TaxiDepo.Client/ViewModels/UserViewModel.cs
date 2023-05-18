using ReactiveUI;
using System;
using System.Reactive;
using TaxiDepo.Client.ViewModels;

namespace TaxiDepo.Client.ViewModels;

public class UserViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _userSurname = string.Empty;

    public string UserSurname
    {
        get => _userSurname;
        set => this.RaiseAndSetIfChanged(ref _userSurname, value);
    }

    private string _userName = string.Empty;

    public string UserName
    {
        get => _userName;
        set => this.RaiseAndSetIfChanged(ref _userName, value);
    }

    private string _userPatronymic = string.Empty;

    public string UserPatronymic
    {
        get => _userPatronymic;
        set => this.RaiseAndSetIfChanged(ref _userPatronymic, value);
    }

    private string _userPhoneNumber = string.Empty;

    public string UserPhoneNumber
    {
        get => _userPhoneNumber;
        set => this.RaiseAndSetIfChanged(ref _userPhoneNumber, value);
    }

    public ReactiveCommand<Unit, UserViewModel> OnSubmitCommand { get; set; }

    public UserViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
