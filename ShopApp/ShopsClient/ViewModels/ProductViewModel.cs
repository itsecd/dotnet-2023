using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _barcode = string.Empty;
    [Required]
    public string Barcode
    {
        get => _barcode;
        set => this.RaiseAndSetIfChanged(ref _barcode, value);
    }
    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    private int _productGroupId;
    [Required]
    public int ProductGroupId
    {
        get => _productGroupId;
        set => this.RaiseAndSetIfChanged(ref _productGroupId, value);
    }
    private double _weight;
    [Required]
    public double Weight
    {
        get => _weight;
        set => this.RaiseAndSetIfChanged(ref _weight, value);
    }
    private string _productType = string.Empty;
    [Required]
    public string ProductType
    {
        get => _productType;
        set => this.RaiseAndSetIfChanged(ref _productType, value);
    }
    private double _price;
    [Required]
    public double Price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }
    private DateTimeOffset _storageLimitDate;
    [Required]
    public DateTimeOffset StorageLimitDate
    {
        get => _storageLimitDate;
        set => this.RaiseAndSetIfChanged(ref _storageLimitDate, value);
    }
    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }

    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
