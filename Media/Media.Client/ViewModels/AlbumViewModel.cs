using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Media.Client.ViewModels;
public class AlbumViewModel : ViewModelBase
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

    private int _year;
    [Required]
    public int Year
    {
        get => _year;
        set => this.RaiseAndSetIfChanged(ref _year, value);
    }

    private int _genreId;
    [Required]
    public int GenreId
    {
        get => _genreId;
        set => this.RaiseAndSetIfChanged(ref _genreId, value);
    }

    private int _artistId;
    [Required]
    public int ArtistId
    {
        get => _artistId;
        set => this.RaiseAndSetIfChanged(ref _artistId, value);
    }

    public ReactiveCommand<Unit, AlbumViewModel> OnSubmitCommand { get; }

    public AlbumViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
