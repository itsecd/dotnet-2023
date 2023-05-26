using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace BikeRental.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BikeViewModel> Bikes { get; } = new();

    private BikeViewModel? _selectedBike;

    public BikeViewModel? SelectedBike
    {
        get => _selectedBike;
        set => this.RaiseAndSetIfChanged(ref _selectedBike, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<BikeViewModel, BikeViewModel?> ShowBikeDialog { get; }

    public MainWindowViewModel() 
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBikeDialog = new Interaction<BikeViewModel, BikeViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bikeViewModel = await ShowBikeDialog.Handle(new BikeViewModel());
            if (bikeViewModel != null)
            {
                var newBike = await _apiClient.AddBikeAsync(_mapper.Map<BikeSetDto>(bikeViewModel));
                Bikes.Add(_mapper.Map<BikeViewModel>(newBike));
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bikeViewModel = await ShowBikeDialog.Handle(SelectedBike!);
            if (bikeViewModel != null)
            {
                await _apiClient.UpdateBikeAsync(SelectedBike!.Id, _mapper.Map<BikeSetDto>(bikeViewModel));
                _mapper.Map(bikeViewModel, SelectedBike);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBike).Select(selectedBike => selectedBike != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBikeAsync(SelectedBike!.Id);
            Bikes.Remove(SelectedBike);
        }, this.WhenAnyValue(vm => vm.SelectedBike).Select(selectedBike => selectedBike != null));

        RxApp.MainThreadScheduler.Schedule(LoadBikesAsync);
    }

    private async void LoadBikesAsync()
    {
        var bikes = await _apiClient.GetBikesAsync();
        foreach (var bike in bikes)
        {
            Bikes.Add(_mapper.Map<BikeViewModel>(bike));
        }
    }
}
