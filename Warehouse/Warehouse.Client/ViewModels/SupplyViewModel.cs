using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace Warehouse.Client.ViewModels;
public class SupplyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private int _quantity;
    [Required]
    public int Quantity
    {
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
        get => _quantity;
    }

    private string _companyName = string.Empty;
    [Required]
    public string CompanyName
    {
        set => this.RaiseAndSetIfChanged(ref _companyName, value);
        get => _companyName;
    }

    private string _companyAddress = string.Empty;
    [Required]
    public string CompanyAddress
    {
        set => this.RaiseAndSetIfChanged(ref _companyAddress, value);
        get => _companyAddress;
    }

    private string? _supplyDate = string.Empty;
    [Required]
    public string? SupplyDate
    {
        set => this.RaiseAndSetIfChanged(ref _supplyDate, value);
        get => _supplyDate;
    }

    public ReactiveCommand<Unit, SupplyViewModel> OnSubmitCommand { get; }

    public SupplyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}