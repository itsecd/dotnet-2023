using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Runtime.Intrinsics.Arm;
using System.Reactive.Linq;

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

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ArtistViewModel, ArtistViewModel?> ShowArtistDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowArtistDialog = new Interaction<ArtistViewModel, ArtistViewModel?> ();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var artistViewModel = await ShowArtistDialog.Handle(new ArtistViewModel());
            if(artistViewModel != null) 
            {
                var newArtist = _mapper.Map<ArtistPostDto>(artistViewModel);
                await _apiClient.AddArtistAsync(newArtist);
                Artists.Add(artistViewModel);
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var artistViewModel = await ShowArtistDialog.Handle(SelectedArtist!);
            if (artistViewModel != null)
            {
                await _apiClient.UpdateArtistAsync(SelectedArtist!.Id, _mapper.Map<ArtistPostDto>(artistViewModel));
                _mapper.Map(artistViewModel, SelectedArtist);
            }
        }, this.WhenAnyValue(vm => vm.SelectedArtist).Select(selectArtist => selectArtist != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteArtistAsync(SelectedArtist!.Id);
            Artists.Remove(SelectedArtist);
        }, this.WhenAnyValue(vm => vm.SelectedArtist).Select(selectArtist => selectArtist != null));

        RxApp.MainThreadScheduler.Schedule(LoadArtistsAsync);
    }

    private async void LoadArtistsAsync()
    {
        var artists = await _apiClient.GetArtistsAsync();
        foreach(var artist in artists) 
        {
            Artists.Add(_mapper.Map<ArtistViewModel>(artist));
        }
    }


}
