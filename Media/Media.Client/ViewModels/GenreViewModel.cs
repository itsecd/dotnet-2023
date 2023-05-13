using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Media.Client.ViewModels;
public class GenreViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public ReactiveCommand<Unit, GenreViewModel> OnSubmitCommand { get; }

    public GenreViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}