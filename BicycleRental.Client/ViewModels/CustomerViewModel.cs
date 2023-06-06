using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace BicycleRental.Client.ViewModels;
public class CustomerViewModel:ViewModelBase
{   
    private int _id;
    [Required]
    public int Id { 
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value); 
    }
    
    private string _fullName = string.Empty;
    [Required]
    public string FullName { 
        get => _fullName; 
        set => this.RaiseAndSetIfChanged(ref _fullName, value); 
    }

    private int _birthYear;
    [Required]
    public int BirthYear { 
        get => _birthYear; 
        set => this.RaiseAndSetIfChanged(ref _birthYear, value); 
    }

    private string _phone = string.Empty;
    [Required]
    public string Phone { 
        get => _phone; 
        set => this.RaiseAndSetIfChanged(ref _phone, value); 
    }

    public ReactiveCommand<Unit, CustomerViewModel> OnSubmitCommand { get; }

    public CustomerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
