using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace BikeRental.Client.ViewModels;
public class BikeTypeViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _typeName = string.Empty;
    [Required]
    public string TypeName
    {
        get => _typeName;
        set => this.RaiseAndSetIfChanged(ref _typeName, value);
    }

    private int _rentCost;
    [Required]
    public int RentCost
    {
        get => _rentCost;
        set => this.RaiseAndSetIfChanged(ref _rentCost, value);
    }

    //public ReactiveCommand<Unit, BikeTypeViewModel> OnSubmitCommand { get; }

    //public BikeTypeViewModel()
    //{
    //    OnSubmitCommand = ReactiveCommand.Create(() => this);
    //}
}
