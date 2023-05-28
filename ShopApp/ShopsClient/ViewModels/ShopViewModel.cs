using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ShopViewModel : ViewModelBase
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
    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }
    public ReactiveCommand<Unit, ShopViewModel> OnSubmitCommand { get; }

    public ShopViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
