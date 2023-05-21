using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace Warehouse.Client.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        set => this.RaiseAndSetIfChanged(ref _name, value);
        get => _name;
    }

    private int _quantity;
    [Required]
    public int Quantity
    {
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
        get => _quantity;
    }

    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }

    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}