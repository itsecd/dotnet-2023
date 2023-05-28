using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ProductQuantityViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _productId;
    [Required]
    public int ProductId
    {
        get => _productId;
        set => this.RaiseAndSetIfChanged(ref _productId, value);
    }
    private int _shopId;
    [Required]
    public int ShopId
    {
        get => _shopId;
        set => this.RaiseAndSetIfChanged(ref _shopId, value);
    }
    private double _quantity;
    [Required]
    public double Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }
    public ReactiveCommand<Unit, ProductQuantityViewModel> OnSubmitCommand { get; }

    public ProductQuantityViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
