using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class RentalPointViewModel : ViewModelBase
{

    private int _id;
    [Required]
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }


    private string _address = string.Empty;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    public ReactiveCommand<Unit, RentalPointViewModel> OnSubmitCommand { get; }

    public RentalPointViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
