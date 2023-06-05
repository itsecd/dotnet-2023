using ReactiveUI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace EnterpriseWarehouse.Client.ViewModels;
public class InvoiceViewModel : ViewModelBase
{
    [Required]
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    private string _nameOrganization;
    public string NameOrganization
    {
        get => _nameOrganization;
        set => this.RaiseAndSetIfChanged(ref _nameOrganization, value);
    }

    [Required]
    private string _addressOrganization;
    public string AddressOrganization
    {
        get => _addressOrganization;
        set => this.RaiseAndSetIfChanged(ref _addressOrganization, value);
    }

    [Required]
    private string _shipmentDate;
    public string ShipmentDate
    {
        get => _shipmentDate;
        set => this.RaiseAndSetIfChanged(ref _shipmentDate, value);
    }

    private Dictionary<int, int>? _info;
    public Dictionary<int, int>? Info
    {
        get => _info;
        set => this.RaiseAndSetIfChanged(ref _info, value);
    }

    public ReactiveCommand<Unit, InvoiceViewModel> OnSubmitCommand { get; }

    public InvoiceViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
