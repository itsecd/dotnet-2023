using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;
using Newtonsoft.Json.Linq;
using System.Reactive;

namespace MusicMarket.Client.ViewModels;
public class CustomerViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _country = string.Empty;
    [Required]
    public string Country
    {
        get => _country;
        set => this.RaiseAndSetIfChanged(ref _country, value);
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
