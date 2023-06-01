using ReactiveUI;
using System;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class ClientViewModel : ViewModelBase
{

    private int _id;

    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;

    }
    private string _firstname = string.Empty;
    public string Firstname
    {
        get => _firstname;
        set => this.RaiseAndSetIfChanged(ref _firstname, value);
    }

    private string _lastname = string.Empty;
    public string Lastname
    {
        get => _lastname;
        set => this.RaiseAndSetIfChanged(ref _lastname, value);
    }

    private string _passport = string.Empty;
    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private DateTimeOffset _birthdate = DateTime.Now;
    public DateTimeOffset Birthdate
    {
        get => _birthdate;
        set => this.RaiseAndSetIfChanged(ref _birthdate, value);
    }
    public ReactiveCommand<Unit, ClientViewModel> OnSubmitCommand { get; }

    public ClientViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}