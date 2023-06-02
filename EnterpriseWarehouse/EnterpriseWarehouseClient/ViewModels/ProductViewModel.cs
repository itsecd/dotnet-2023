using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace EnterpriseWarehouseClient.ViewModels;

public class ProductViewModel : ViewModelBase
{
    [Required]
    private int _itemNumber;
    public int ItemNumber
    {
        get => _itemNumber;
        set => this.RaiseAndSetIfChanged(ref _itemNumber, value);
    }

    [Required]
    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    [Required]
    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }

    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }

    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
