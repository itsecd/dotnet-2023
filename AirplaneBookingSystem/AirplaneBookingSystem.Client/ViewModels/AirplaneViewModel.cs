using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AirplaneBookingSystem.Client.ViewModels;
public class AirplaneViewModel : ViewModelBase
{
    private int _id;
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
    public ReactiveCommand<Unit, AirplaneViewModel> OnSubmitCommand { get; }
    public AirplaneViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}