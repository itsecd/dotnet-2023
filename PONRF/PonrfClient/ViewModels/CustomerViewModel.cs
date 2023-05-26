using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;
public class CustomerViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _fio = string.Empty;
    [Required]
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }

    private string _passport = string.Empty;
    [Required]
    public string Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    public ReactiveCommand<Unit, CustomerViewModel> OnSubmitCommand { get; }
    public CustomerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
