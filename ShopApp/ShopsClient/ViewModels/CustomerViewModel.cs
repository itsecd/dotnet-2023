using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class CustomerViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _firstName = string.Empty;
    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    private string _lastName = string.Empty;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
    private string _middleName = string.Empty;
    [Required]
    public string MiddleName
    {
        get => _middleName;
        set => this.RaiseAndSetIfChanged(ref _middleName, value);
    }
    private string _cardCount = string.Empty;
    [Required]
    public string CardCount
    {
        get => _cardCount;
        set => this.RaiseAndSetIfChanged(ref _cardCount, value);
    }

    public ReactiveCommand<Unit, CustomerViewModel> OnSubmitCommand { get; }

    public CustomerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
