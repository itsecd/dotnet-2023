using EnterpriseWarehouseClient.ViewModels;
using ReactiveUI;

namespace EnterpriseWarehouse.Client.ViewModels;

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
}
