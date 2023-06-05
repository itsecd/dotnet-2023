using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace MusicMarket.Client.ViewModels;
public class SellerViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _shopname = string.Empty;
    [Required]
    public string ShopName
    {
        get => _shopname;
        set => this.RaiseAndSetIfChanged(ref _shopname, value);
    }

    private string _countryOfDelivery = string.Empty;
    [Required]
    public string CountryOfDelivery
    {
        get => _countryOfDelivery;
        set => this.RaiseAndSetIfChanged(ref _countryOfDelivery, value);
    }

    private double _price;
    [Required]
    public double Price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }
    public ReactiveCommand<Unit, SellerViewModel> OnSubmitCommand { get; }

    public SellerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
