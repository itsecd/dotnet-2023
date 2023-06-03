using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace EnterpriseWarehouseClient.ViewModels;
public class StorageCellViewModel : ViewModelBase
{
    [Required]
    private int _number;
    public int Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    [Required]
    private int _productIN;
    public int ProductIN
    {
        get => _productIN;
        set => this.RaiseAndSetIfChanged(ref _productIN, value);
    }

    public ReactiveCommand<Unit, StorageCellViewModel> OnSubmitCommand { get; }

    public StorageCellViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
