using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;

namespace BikeRental.Client.ViewModels;
public class BikeViewModel : ViewModelBase
{
    private int _id;
    public int Id 
    { 
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value); 
    }

    private int _serialNumber;
    [Required]
    public int SerialNumber
    {
        get => _serialNumber;
        set => this.RaiseAndSetIfChanged(ref _serialNumber, value);
    }

    private string _model = string.Empty;
    [Required]
    public string Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    private string _color = string.Empty;
    [Required]
    public string Color
    {
        get => _color;
        set => this.RaiseAndSetIfChanged(ref _color, value);
    }

    private int _typeId;
    [Required]
    public int TypeId
    {
        get => _typeId; 
        set => this.RaiseAndSetIfChanged(ref _typeId, value);
    }

    public ReactiveCommand<Unit, BikeViewModel> OnSubmitCommand { get; }

    public BikeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
