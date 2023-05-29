using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class CarViewModel : ViewModelBase
{

    private int _id;
    [Required]
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    
    private string _model = string.Empty;
    [Required]
    public string Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }
    
    private string _colour = string.Empty;
    [Required]
    public string Colour
    {
        get => _colour;
        set => this.RaiseAndSetIfChanged(ref _colour, value);
    }

    private string _number = string.Empty;
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    public ReactiveCommand<Unit, CarViewModel> OnSubmitCommand { get; }

    public CarViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
