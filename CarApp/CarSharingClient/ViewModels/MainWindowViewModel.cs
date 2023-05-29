using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace CarSharingClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ObservableCollection<CarViewModel> Cars { get; } = new();
    public ObservableCollection<RentalPointViewModel> RentalPoints { get; } = new();

    private CarViewModel? _selectedCar;
    public CarViewModel? SelectedCar
    {
        get => _selectedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedCar, value);
    }
    private RentalPointViewModel? _selectedRentalPoint;
    public RentalPointViewModel? SelectedRentalPoint
    {
        get => _selectedRentalPoint;
        set => this.RaiseAndSetIfChanged(ref _selectedRentalPoint, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCarCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCarCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRentalPointCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentalPointCommand { get; set; }

    public Interaction<CarViewModel, CarViewModel?> ShowCarDialog { get;}
    public Interaction<RentalPointViewModel, RentalPointViewModel?> ShowRentalPointDialog { get; }
    

    public MainWindowViewModel() { 
        _apiClient=Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCarDialog = new Interaction<CarViewModel, CarViewModel?>();
        ShowRentalPointDialog = new Interaction<RentalPointViewModel, RentalPointViewModel?>();

        OnAddCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(new CarViewModel());
            if (carViewModel!=null)
            {
                var newCar = _mapper.Map<CarPostDto>(carViewModel);
                await _apiClient.AddCarsAsync(newCar);
                Cars.Add(carViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                LoadCarsAsync();
            }
        });
        OnChangeCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(SelectedCar!);
            if (carViewModel != null)
            {
                await _apiClient.UpdateCarsAsync(SelectedCar!.Id, _mapper.Map<CarPostDto>(carViewModel));
                _mapper.Map(carViewModel, SelectedCar);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectCar => selectCar != null));
        OnDeleteCarCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCarsAsync(SelectedCar!.Id);
            Cars.Remove(SelectedCar);
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectCar => selectCar != null));


        OnAddRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalPointViewModel = await ShowRentalPointDialog.Handle(new RentalPointViewModel());
            if (rentalPointViewModel != null)
            {
                var newRentalPoint = _mapper.Map<RentalPointPostDto>(rentalPointViewModel);
                await _apiClient.AddRentalPointsAsync(newRentalPoint);
                RentalPoints.Add(rentalPointViewModel);
                Cars.Clear();
                RentalPoints.Clear();
                LoadRentalPointsAsync();
            }
        });
        OnChangeRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalPointViewModel = await ShowRentalPointDialog.Handle(SelectedRentalPoint!);
            if (rentalPointViewModel != null)
            {
                await _apiClient.UpdateRentalPointsAsync(SelectedRentalPoint!.Id, _mapper.Map<RentalPointPostDto>(rentalPointViewModel));
                _mapper.Map(rentalPointViewModel, SelectedRentalPoint);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint).Select(selectRentalPoint => selectRentalPoint != null));
        OnDeleteRentalPointCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentalPointsAsync(SelectedRentalPoint!.Id);
            RentalPoints.Remove(SelectedRentalPoint);
        }, this.WhenAnyValue(vm => vm.SelectedRentalPoint).Select(selectRentalPoint => selectRentalPoint != null));

        RxApp.MainThreadScheduler.Schedule(LoadCarsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRentalPointsAsync);
    }
    private async void LoadCarsAsync()
    {
        var cars = await _apiClient.GetCarsAsync();
        foreach (var car in cars)
        {
            Cars.Add(_mapper.Map<CarViewModel>(car));
        }
    }
     private async void LoadRentalPointsAsync()
    {
        var rentalPoints = await _apiClient.GetRentalPointsAsync();
        foreach (var rentalPoint in rentalPoints)
        {
            RentalPoints.Add(_mapper.Map<RentalPointViewModel>(rentalPoint));
        }
    }
}

