using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Library.Client.ViewModels;
public class BookViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _cipher = string.Empty;
    [Required]
    public string Cipher
    {
        set => this.RaiseAndSetIfChanged(ref _cipher, value);
        get => _cipher;
    }

    private string _author = string.Empty;
    [Required]
    public string Author
    {
        set => this.RaiseAndSetIfChanged(ref _author, value);
        get => _author;
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        set => this.RaiseAndSetIfChanged(ref _name, value);
        get => _name;
    }

    private string _placeEdition = string.Empty;
    [Required]
    public string PlaceEdition
    {
        set => this.RaiseAndSetIfChanged(ref _placeEdition, value);
        get => _placeEdition;
    }

    private int _yearEdition;
    [Required]
    public int YearEdition
    {
        set => this.RaiseAndSetIfChanged(ref _yearEdition, value);
        get => _yearEdition;
    }

    private int _typeEditionId;
    [Required]
    public int TypeEditionId
    {
        set => this.RaiseAndSetIfChanged(ref _typeEditionId, value);
        get => _typeEditionId;
    }

    public ReactiveCommand<Unit, BookViewModel> OnSubmitCommand { get; }

    public BookViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}