using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace Warehouse.Client.ViewModels;
public class WarehouseCellViewModel : ViewModelBase
{
    private int _cellNumber;
    [Required]
    public int CellNumber
    {
        set => this.RaiseAndSetIfChanged(ref _cellNumber, value);
        get => _cellNumber;
    }

    public ReactiveCommand<Unit, WarehouseCellViewModel> OnSubmitCommand { get; }

    public WarehouseCellViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}