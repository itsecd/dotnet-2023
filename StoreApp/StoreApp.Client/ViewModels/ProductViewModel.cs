using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace StoreApp.Client.ViewModels;

public class ProductViewModel : ViewModelBase
{
    private int _productId;
    public int ProductId
    {
        get => _productId;
        set => this.RaiseAndSetIfChanged(ref _productId, value);
    }

    [Required]
    private int _productGroup;
    public int ProductGroup {
        get => _productGroup;
        set => this.RaiseAndSetIfChanged(ref _productGroup, value);
    }

    [Required]
    private string _productName = string.Empty;
    public string ProductName { 
        get => _productName;
        set => this.RaiseAndSetIfChanged(ref _productName, value);
    }

    [Required]
    private double _productWeight = 0.0;
    public double ProductWeight {
        get => _productWeight;
        set => this.RaiseAndSetIfChanged(ref _productWeight, value);
    }

    [Required]
    private bool _productType = false;
    public bool ProductType {
        get => _productType;
        set => this.RaiseAndSetIfChanged(ref _productType, value);
    }

    [Required]
    private double _productPrice = -1.0;
    public double ProductPrice
    {
        get => _productPrice;
        set => this.RaiseAndSetIfChanged(ref _productPrice, value);
    }

    [Required]
    public DateTimeOffset? DateStorage { get; set; } = DateTimeOffset.Now;

    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommandProduct { get; }
    public ProductViewModel()
    {
        OnSubmitCommandProduct = ReactiveCommand.Create(() => this);
    }
}
