using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;
public class TopCustomerViewModel : ViewModelBase
{
    private string _fio = string.Empty;
    [Required]
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }

    private int _total;
    [Required]
    public int Total
    {
        get => _total;
        set => this.RaiseAndSetIfChanged(ref _total, value);
    }

    public ReactiveCommand<Unit, TopCustomerViewModel> OnSubmitCommand { get; }
    public TopCustomerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
