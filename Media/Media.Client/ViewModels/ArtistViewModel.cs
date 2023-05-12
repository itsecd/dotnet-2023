using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Media.Client.ViewModels;
public class ArtistViewModel : ViewModelBase
{
    private int _id;
    public int Id 
    {
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;
    [Required]
    public string Name { 
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _description = string.Empty;
    [Required]
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public ReactiveCommand<Unit, ArtistViewModel> OnSubmitCommand { get; }

    public ArtistViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
