
using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace BicycleRental.Client.ViewModels;
public class BicycleTypeViewModel : ViewModelBase
{
    private int _typeId;
    [Required]
    public int TypeId { 
        get => _typeId; 
        set => this.RaiseAndSetIfChanged(ref _typeId, value); 
    }

    private string _typeName = string.Empty;
    [Required]
    public string TypeName { 
        get => _typeName; 
        set => this.RaiseAndSetIfChanged(ref _typeName, value); 
    }

    public ReactiveCommand<Unit, BicycleTypeViewModel> OnSubmitCommand { get; }

    public BicycleTypeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
