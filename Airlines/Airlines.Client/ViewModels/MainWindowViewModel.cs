using Airlines.Client.ViewModels;
using Airlines.Client;
using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive;
using System.Reactive.Linq;

namespace Airlines.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PassengerViewModel> Passengers { get; } = new();

    private PassengerViewModel? _selectedPassenger;
    public PassengerViewModel? SelectedPassenger
    {
        get => _selectedPassenger;
        set => this.RaiseAndSetIfChanged(ref _selectedPassenger, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<PassengerViewModel, PassengerViewModel?> ShowPassengerDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        
        ShowPassengerDialog = new Interaction<PassengerViewModel, PassengerViewModel?> ();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var passengerViewModel = await ShowPassengerDialog.Handle(new PassengerViewModel());
            if (passengerViewModel != null)
            {
                var newArtist = _mapper.Map<PassengerPostDto>(passengerViewModel);
                await _apiClient.AddPassengerAsync(newArtist);
                Passengers.Add(passengerViewModel);
            }
        });
        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var artistViewModel = await ShowPassengerDialog.Handle(SelectedPassenger!);
            if (artistViewModel != null)
            {
                await _apiClient.UpdatePassengerAsync(SelectedPassenger!.Id, _mapper.Map<PassengerPostDto>(artistViewModel));
                _mapper.Map(artistViewModel, SelectedPassenger);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPassenger).Select(selectArtist => selectArtist != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePassengerAsync(SelectedPassenger!.Id);
            Passengers.Remove(SelectedPassenger);
        }, this.WhenAnyValue(vm => vm.SelectedPassenger).Select(selectArtist => selectArtist != null));
        RxApp.MainThreadScheduler.Schedule(LoadArtistsAsync);
    }

    private async void LoadArtistsAsync()
    {
        var artists = await _apiClient.GetPassengersAsync();
        foreach (var artist in artists)
        {
            Passengers.Add(_mapper.Map<PassengerViewModel>(artist));
        }
    }
}