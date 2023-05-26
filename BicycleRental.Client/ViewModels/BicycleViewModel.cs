using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;
using BicycleRental.Client.ViewModels;
using System.Reactive;

namespace BicycleRental.Client.ViewModels;
public class BicycleViewModel:ViewModelBase
{
    private int _serial;
    [Required]
    public int SerialNumber { 
        get => _serial; 
        set =>this.RaiseAndSetIfChanged(ref _serial,value); 
    }

    private int _typeId;
    [Required]
    public int TypeId { 
        get => _typeId; 
        set => this.RaiseAndSetIfChanged(ref _typeId, value); 
    }

    private string _model = string.Empty;
    [Required]
    public string Model { 
        get => _model; 
        set => this.RaiseAndSetIfChanged(ref _model, value); 
    }

    private string _color = string.Empty;
    [Required]
    public string Color { 
        get => _color; 
        set => this.RaiseAndSetIfChanged(ref _color, value); 
    }

    public ReactiveCommand<Unit, BicycleViewModel> OnSubmitCommand { get; }

    public BicycleViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
