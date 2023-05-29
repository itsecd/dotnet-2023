using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace HotelBookingSystem.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<HotelViewModel> Hotels { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> AddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> EditCommand { get; set; }

    public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }

    public Interaction<HotelViewModel, HotelViewModel?> ShowHotelDialog { get; }

    private HotelViewModel? _selected;

    private HotelViewModel? Selected
    {
        get => _selected; 
        set => this.RaiseAndSetIfChanged(ref _selected, value);
    }

    private async void LoadHotelsAsync()
    {
        var hotels = await _apiClient.GetHotelsAsync();
        foreach(var hotel in hotels)
        {
            Hotels.Add(_mapper.Map<HotelViewModel>(hotel));
        }
    }

    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowHotelDialog = new Interaction<HotelViewModel, HotelViewModel?>();

        AddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var hotelViewModel = await ShowHotelDialog.Handle(new HotelViewModel());
            if (hotelViewModel != null) 
            {
                var newHotel = await _apiClient.PostHotelsAsync(_mapper.Map<HotelPostDto>(hotelViewModel));
                Hotels.Add(_mapper.Map<HotelViewModel>(newHotel));
            }
        });

        EditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var hotelViewModel = await ShowHotelDialog.Handle(Selected);
            if (hotelViewModel != null)
            {
                await _apiClient.PutHotelsAsync(Selected!.Id, _mapper.Map<HotelPostDto>(hotelViewModel));
                _mapper.Map(hotelViewModel, Selected);
            }
        },
        this.WhenAnyValue(vm => vm.Selected).Select(_selected => _selected != null)
        );

        DeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteHotelsAsync(Selected!.Id);
            Hotels.Remove(Selected);
        },
        this.WhenAnyValue(vm => vm.Selected).Select(_selected => _selected != null)
        );

        RxApp.MainThreadScheduler.Schedule(LoadHotelsAsync);
    }
}
