using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PharmacyCityNetwork.Client.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _productName = string.Empty;
    [Required]
    public string ProductName
    {
        get => _productName;
        set => this.RaiseAndSetIfChanged(ref _productName, value);
    }
    private int _groupId;
    [Required]
    public int GroupId
    {
        get => _groupId;
        set => this.RaiseAndSetIfChanged(ref _groupId, value);
    }
    private int _manufacturerId;
    [Required]
    public int ManufacturerId
    {
        get => _manufacturerId;
        set => this.RaiseAndSetIfChanged(ref _manufacturerId, value);
    }
    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }
    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}