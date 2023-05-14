using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace AirplaneBookingSystem.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<AirplaneViewModel> Airplanes { get; } = new();

    private AirplaneViewModel? _selectedAirplane;
    public AirplaneViewModel? SelectedAirplane
    {
        get => _selectedAirplane;
        set => this.RaiseAndSetIfChanged(ref _selectedAirplane, value);
    }

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public ReactiveCommand<Unit,Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }
    public Interaction<AirplaneViewModel, AirplaneViewModel?> ShowAirplaneDialog { get; set; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        ShowAirplaneDialog = new Interaction<AirplaneViewModel, AirplaneViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(new AirplaneViewModel());
            if (airplaneViewModel != null) 
            {
                var newAirplane = await _apiClient.AddAirplaneAsync(_mapper.Map<AirplanePostDto>(airplaneViewModel));
                Airplanes.Add(_mapper.Map<AirplaneViewModel>(newAirplane));
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var airplaneViewModel = await ShowAirplaneDialog.Handle(SelectedAirplane!);
            if (airplaneViewModel != null)
            {
                await _apiClient.UpdateAirplaneAsync(SelectedAirplane!.Id, _mapper.Map<AirplanePostDto>(airplaneViewModel));
                _mapper.Map(airplaneViewModel, SelectedAirplane);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectedAirplane => selectedAirplane != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAirplaneAsync(SelectedAirplane!.Id);
            Airplanes.Remove(SelectedAirplane);
                
        }, this.WhenAnyValue(vm => vm.SelectedAirplane).Select(selectedAirplane => selectedAirplane != null));

        RxApp.MainThreadScheduler.Schedule(LoadAirplanesAsync);
    }

    private async void LoadAirplanesAsync()
    {
        var airplanes = await _apiClient.GetAirplanesAsync();
        foreach (var airplane in airplanes)
        {
            Airplanes.Add(_mapper.Map<AirplaneViewModel>(airplane));
        }
    }
}