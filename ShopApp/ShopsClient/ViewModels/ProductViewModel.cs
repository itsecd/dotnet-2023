using ReactiveUI;
using System;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id { 
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    } 
    private string _barcode = string.Empty;
    public string Barcode {
        get => _barcode;
        set => this.RaiseAndSetIfChanged(ref _barcode, value); 
    } 
    private string _name = string.Empty;
    public string Name { 
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value); 
    } 
    private int _productGroupId;
    public int ProductGroupId {
        get => _productGroupId;
        set => this.RaiseAndSetIfChanged(ref _productGroupId, value); 
    } 
    private double _weight;
    public double Weight { 
        get => _weight;
        set => this.RaiseAndSetIfChanged(ref _weight, value);
    } 
    private string _productType = string.Empty;
    public string ProductType { 
        get => _productType;
        set => this.RaiseAndSetIfChanged(ref _productType, value); 
    } 
    private double _price;
    public double Price { 
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value); 
    } 
    private DateTime _storageLimitDate;
    public DateTime StorageLimitDate { 
        get => _storageLimitDate;
        set => this.RaiseAndSetIfChanged(ref _storageLimitDate, value); 
    }
    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }

    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
