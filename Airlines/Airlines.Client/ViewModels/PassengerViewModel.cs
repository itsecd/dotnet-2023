using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Airlines.Client.ViewModels;
public class PassengerViewModel : ViewModelBase
{
    private int _id;
    public int Id { 
        get=>_id; 
        set=>this.RaiseAndSetIfChanged(ref _id,value); 
    }
    private string _passportNumber=string.Empty;
    [Required]
    public string? PassportNumber
    {
        get => _passportNumber;
        set => this.RaiseAndSetIfChanged(ref _passportNumber, value);
    }
    private string _name = string.Empty;
    [Required]
    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public ReactiveCommand<Unit, PassengerViewModel> OnSubmitCommand { get; }

    public PassengerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
