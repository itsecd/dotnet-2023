using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class CarViewModel : ViewModelBase
{

    private int _id;

    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;

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
        set => this.RaiseAndSetIfChanged(ref _number, value);
        get => _number;

    }

    public ReactiveCommand<Unit, CarViewModel> OnSubmitCommand { get; }

    public CarViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
