using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace EnterpriseWarehouseClient.ViewModels;

public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

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
