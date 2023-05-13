using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Runtime.Intrinsics.Arm;
using System.Reactive.Linq;
using DynamicData;

namespace Media.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ArtistViewModel> Artists { get; } = new();

    private ArtistViewModel? _selectedArtist;
    public ArtistViewModel? SelectedArtist
    {
        get => _selectedArtist;
        set =>  this.RaiseAndSetIfChanged(ref _selectedArtist, value);
    }

    public ObservableCollection<AlbumViewModel> Albums { get; } = new();

    private AlbumViewModel? _selectedAlbum;
    public AlbumViewModel? SelectedAlbum
    {
        get => _selectedAlbum;
        set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
    }

    public ObservableCollection<GenreViewModel> Genres { get; } = new();

    private GenreViewModel? _selectedGenre;
    public GenreViewModel? SelectedGenre
    {
        get => _selectedGenre;
        set => this.RaiseAndSetIfChanged(ref _selectedGenre, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddArtistCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeArtistCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteArtistCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddAlbumCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeAlbumCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteAlbumCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddGenreCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeGenreCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteGenreCommand { get; set; }

    public Interaction<GenreViewModel, GenreViewModel?> ShowGenreDialog { get; }

    public Interaction<AlbumViewModel, AlbumViewModel?> ShowAlbumDialog { get; }

    public Interaction<ArtistViewModel, ArtistViewModel?> ShowArtistDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowArtistDialog = new Interaction<ArtistViewModel, ArtistViewModel?> ();

        OnAddArtistCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var artistViewModel = await ShowArtistDialog.Handle(new ArtistViewModel());
            if(artistViewModel != null) 
            {
                var newArtist = _mapper.Map<ArtistPostDto>(artistViewModel);
                await _apiClient.AddArtistAsync(newArtist);
                Artists.Add(artistViewModel);
                RxApp.MainThreadScheduler.Schedule(LoadArtistsAsync);
            }
        });

        OnChangeArtistCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var artistViewModel = await ShowArtistDialog.Handle(SelectedArtist!);
            if (artistViewModel != null)
            {
                await _apiClient.UpdateArtistAsync(SelectedArtist!.Id, _mapper.Map<ArtistPostDto>(artistViewModel));
                _mapper.Map(artistViewModel, SelectedArtist);
            }
        }, this.WhenAnyValue(vm => vm.SelectedArtist).Select(selectArtist => selectArtist != null));

        OnDeleteArtistCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteArtistAsync(SelectedArtist!.Id);
            Artists.Remove(SelectedArtist);

        }, this.WhenAnyValue(vm => vm.SelectedArtist).Select(selectArtist => selectArtist != null));

        RxApp.MainThreadScheduler.Schedule(LoadArtistsAsync);

        ShowAlbumDialog = new Interaction<AlbumViewModel, AlbumViewModel?>();

        OnAddAlbumCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var albumViewModel = await ShowAlbumDialog.Handle(new AlbumViewModel());
            if (albumViewModel != null)
            {
                var newAlbum = _mapper.Map<AlbumPostDto>(albumViewModel);
                await _apiClient.AddAlbumAsync(newAlbum);
                Albums.Add(albumViewModel);
                RxApp.MainThreadScheduler.Schedule(LoadAlbumsAsync);
            }
        });

        OnChangeAlbumCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var albumViewModel = await ShowAlbumDialog.Handle(SelectedAlbum!);
            if (albumViewModel != null)
            {
                await _apiClient.UpdateAlbumAsync(SelectedAlbum!.Id, _mapper.Map<AlbumPostDto>(albumViewModel));
                _mapper.Map(albumViewModel, SelectedAlbum);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAlbum).Select(selectAlbum => selectAlbum != null));

        OnDeleteAlbumCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAlbumAsync(SelectedAlbum!.Id);
            Albums.Remove(SelectedAlbum);
        }, this.WhenAnyValue(vm => vm.SelectedAlbum).Select(selectAlbum => selectAlbum != null));

        RxApp.MainThreadScheduler.Schedule(LoadAlbumsAsync);

        ShowGenreDialog = new Interaction<GenreViewModel, GenreViewModel?>();

        OnAddGenreCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var genreViewModel = await ShowGenreDialog.Handle(new GenreViewModel());
            if (genreViewModel != null)
            {
                var newGenre = _mapper.Map<GenrePostDto>(genreViewModel);
                await _apiClient.AddGenreAsync(newGenre);
                Genres.Add(genreViewModel);
                RxApp.MainThreadScheduler.Schedule(LoadGenresAsync);
            }
        });

        OnChangeGenreCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var genreViewModel = await ShowGenreDialog.Handle(SelectedGenre!);
            if (genreViewModel != null)
            {
                await _apiClient.UpdateGenreAsync(SelectedGenre!.Id, _mapper.Map<GenrePostDto>(genreViewModel));
                _mapper.Map(genreViewModel, SelectedGenre);
            }
        }, this.WhenAnyValue(vm => vm.SelectedGenre).Select(selectGenre => selectGenre != null));

        OnDeleteGenreCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteGenreAsync(SelectedGenre!.Id);
            Genres.Remove(SelectedGenre);
        }, this.WhenAnyValue(vm => vm.SelectedGenre).Select(selectGenre => selectGenre != null));

        RxApp.MainThreadScheduler.Schedule(LoadGenresAsync);
    }

    private async void LoadArtistsAsync()
    {
        Artists.Clear();
        var artists = await _apiClient.GetArtistsAsync();
        foreach(var artist in artists) 
        {
            Artists.Add(_mapper.Map<ArtistViewModel>(artist));
        }
    }

    private async void LoadAlbumsAsync()
    {
        Albums.Clear();
        var albums = await _apiClient.GetAlbumsAsync();
        foreach (var album in albums)
        {
            Albums.Add(_mapper.Map<AlbumViewModel>(album));
        }
    }

    private async void LoadGenresAsync()
    {
        Genres.Clear();
        var genres = await _apiClient.GetGenresAsync();
        foreach (var genre in genres)
        {
            Genres.Add(_mapper.Map<GenreViewModel>(genre));
        }
    }
}
