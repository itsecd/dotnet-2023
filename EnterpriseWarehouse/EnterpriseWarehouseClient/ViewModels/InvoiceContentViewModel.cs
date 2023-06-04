using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace EnterpriseWarehouseClient.ViewModels;
public class InvoiceContentViewModel : ViewModelBase
{
    [Required]
    private int _invoiceId;
    public int InvoiceId
    {
        get => _invoiceId;
        set => this.RaiseAndSetIfChanged(ref _invoiceId, value);
    }

    [Required]
    private int _productIN;
    public int ProductIN
    {
        get => _productIN;
        set => this.RaiseAndSetIfChanged(ref _productIN, value);
    }

    [Required]
    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }

    public ReactiveCommand<Unit, InvoiceContentViewModel> OnSubmitCommand { get; }

    public InvoiceContentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
