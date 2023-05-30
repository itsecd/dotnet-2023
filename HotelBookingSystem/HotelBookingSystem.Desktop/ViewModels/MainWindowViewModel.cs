using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System;

namespace HotelBookingSystem.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<HotelViewModel> Hotels { get; } = new();
    public ObservableCollection<RoomViewModel> Rooms { get; } = new();
    public ObservableCollection<LodgerViewModel> Lodgers { get; } = new();
    public ObservableCollection<BookedRoomsViewModel> Brooms { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> HotelAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> HotelEditCommand { get; set; }
    public ReactiveCommand<Unit, Unit> HotelDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> RoomAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> RoomEditCommand { get; set; }
    public ReactiveCommand<Unit, Unit> RoomDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> LodgerAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> LodgerEditCommand { get; set; }
    public ReactiveCommand<Unit, Unit> LodgerDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> BroomsAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> BroomsEditCommand { get; set; }
    public ReactiveCommand<Unit, Unit> BroomsDeleteCommand { get; set; }

    public Interaction<HotelViewModel, HotelViewModel?> ShowHotelDialog { get; }
    public Interaction<RoomViewModel, RoomViewModel?> ShowRoomDialog { get; }
    public Interaction<LodgerViewModel, LodgerViewModel?> ShowLodgerDialog { get; }
    public Interaction<BookedRoomsViewModel, BookedRoomsViewModel?> ShowBroomDialog { get; }

    private HotelViewModel? _selectedHotel;
    private RoomViewModel? _selectedRoom;
    private LodgerViewModel? _selectedLodger;
    private BookedRoomsViewModel? _selectedBroom;

    private HotelViewModel? SelectedHotel
    {
        get => _selectedHotel; 
        set => this.RaiseAndSetIfChanged(ref _selectedHotel, value);
    }
    private RoomViewModel? SelectedRoom
    {
        get => _selectedRoom;
        set => this.RaiseAndSetIfChanged(ref _selectedRoom, value);
    }
    private LodgerViewModel? Selectedlodger
    {
        get => _selectedLodger;
        set => this.RaiseAndSetIfChanged(ref _selectedLodger, value);
    }
    private BookedRoomsViewModel? SelectedBroom
    {
        get => _selectedBroom;
        set => this.RaiseAndSetIfChanged(ref _selectedBroom, value);
    }

    private async void LoadDataAsync()
    {
        var hotels = await _apiClient.GetHotelsAsync();
        foreach (var hotel in hotels)
        {
            Hotels.Add(_mapper.Map<HotelViewModel>(hotel));
        }
        var rooms = await _apiClient.GetRoomsAsync();
        foreach (var room in rooms)
        {
            Rooms.Add(_mapper.Map<RoomViewModel>(room));
        }
        var lodgers = await _apiClient.GetLodgersAsync();
        foreach (var lodger in lodgers)
        {
            Lodgers.Add(_mapper.Map<LodgerViewModel>(lodger));
        }
        var brooms = await _apiClient.GetBroomsAsync();
        foreach (var broom in brooms)
        {
            try
            { Brooms.Add(_mapper.Map<BookedRoomsViewModel>(broom)); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }

    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowHotelDialog = new Interaction<HotelViewModel, HotelViewModel?>();

        HotelAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var hotelViewModel = await ShowHotelDialog.Handle(new HotelViewModel());
            if (hotelViewModel != null) 
            {
                var newHotel = await _apiClient.PostHotelsAsync(_mapper.Map<HotelPostDto>(hotelViewModel));
                Hotels.Add(_mapper.Map<HotelViewModel>(newHotel));
            }
        });

        HotelEditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedHotel != null)
            {
                var hotelViewModel = await ShowHotelDialog.Handle(SelectedHotel);
                if (hotelViewModel != null)
                {
                    await _apiClient.PutHotelsAsync(SelectedHotel!.Id, _mapper.Map<HotelPostDto>(hotelViewModel));
                    _mapper.Map(hotelViewModel, SelectedHotel);
                }
            }
        },
        this.WhenAnyValue(vm => vm.SelectedHotel).Select(_selected => _selected != null)
        );

        HotelDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteHotelsAsync(SelectedHotel!.Id);
            Hotels.Remove(SelectedHotel);
        },
        this.WhenAnyValue(vm => vm.SelectedHotel).Select(_selected => _selected != null)
        );

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }
}
