using ReactiveUI;
using System.Reactive;

namespace RealtorClient.ViewModels;
public class ClientViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _passport;
    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }
    private string _number;
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }
    private string _registration;
    public string Registration
    {
        get => _registration;
        set => this.RaiseAndSetIfChanged(ref _registration, value);
    }
    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    private string _surname;
    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    public ReactiveCommand<Unit, ClientViewModel> OnSubmitCommand { get; }

    public ClientViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
