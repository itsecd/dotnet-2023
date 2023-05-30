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


    public ReactiveCommand<Unit, Unit> InfoHotelsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> InfoClientsInHotelCommand { get; set; }
    public ReactiveCommand<Unit, Unit> Top5MostBookedCommand { get; set; }
    public ReactiveCommand<Unit, Unit> AvailableRoomsCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ClientsWithMostDaysCommand { get; set; }


    public Interaction<HotelViewModel, HotelViewModel?> ShowHotelDialog { get; }
    public Interaction<RoomViewModel, RoomViewModel?> ShowRoomDialog { get; }
    public Interaction<LodgerViewModel, LodgerViewModel?> ShowLodgerDialog { get; }
    public Interaction<BookedRoomsViewModel, BookedRoomsViewModel?> ShowBroomDialog { get; }

    public Interaction<InfoHotelsViewModel, InfoHotelsViewModel?> ShowInfoHotels { get; }
    public Interaction<InfoClientsInHotelViewModel, InfoClientsInHotelViewModel?> ShowInfoClientsInHotel { get; }
    public Interaction<Top5MostBookedViewModel, Top5MostBookedViewModel?> ShowTop5MostBooked { get; }
    public Interaction<AvailableRoomsViewModel, AvailableRoomsViewModel?> ShowAvailableRooms { get; }
    public Interaction<ClientsWithMostDaysViewModel, ClientsWithMostDaysViewModel?> ShowClientsWithMostDays { get; }


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
    private LodgerViewModel? SelectedLodger
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
            Brooms.Add(_mapper.Map<BookedRoomsViewModel>(broom));
        }
    }

    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowHotelDialog = new Interaction<HotelViewModel, HotelViewModel?>();
        ShowRoomDialog = new Interaction<RoomViewModel, RoomViewModel?>();
        ShowLodgerDialog = new Interaction<LodgerViewModel, LodgerViewModel?>();
        ShowBroomDialog = new Interaction<BookedRoomsViewModel, BookedRoomsViewModel?>();

        ShowInfoHotels = new Interaction<InfoHotelsViewModel, InfoHotelsViewModel?>();
        ShowInfoClientsInHotel = new Interaction<InfoClientsInHotelViewModel, InfoClientsInHotelViewModel?>();
        ShowTop5MostBooked = new Interaction<Top5MostBookedViewModel, Top5MostBookedViewModel?>();
        ShowAvailableRooms = new Interaction<AvailableRoomsViewModel, AvailableRoomsViewModel?>();
        ShowClientsWithMostDays = new Interaction<ClientsWithMostDaysViewModel, ClientsWithMostDaysViewModel?>();


        /// <summary>
        /// Hotel ADD, EDIT and DELETE actions
        /// </summary>

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

        /// <summary>
        /// Room ADD, EDIT and DELETE actions
        /// </summary>

        RoomAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var roomViewModel = await ShowRoomDialog.Handle(new RoomViewModel());
            if (roomViewModel != null)
            {
                var newRoom = await _apiClient.PostRoomsAsync(_mapper.Map<RoomPostDto>(roomViewModel));
                Rooms.Add(_mapper.Map<RoomViewModel>(newRoom));
            }
        });

        RoomEditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedRoom != null)
            {
                var roomViewModel = await ShowRoomDialog.Handle(SelectedRoom);
                if (roomViewModel != null)
                {
                    await _apiClient.PutRoomsAsync(SelectedRoom!.Id, _mapper.Map<RoomPostDto>(roomViewModel));
                    _mapper.Map(roomViewModel, SelectedRoom);
                }
            }
        },
        this.WhenAnyValue(vm => vm.SelectedRoom).Select(_selected => _selected != null)
        );

        RoomDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRoomsAsync(SelectedRoom!.Id);
            Rooms.Remove(SelectedRoom);
        },
        this.WhenAnyValue(vm => vm.SelectedRoom).Select(_selected => _selected != null)
        );

        /// <summary>
        /// Lodger ADD, EDIT and DELETE actions
        /// </summary>

        LodgerAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var lodgerViewModel = await ShowLodgerDialog.Handle(new LodgerViewModel());
            if (lodgerViewModel != null)
            {
                var newLodger = await _apiClient.PostLodgersAsync(_mapper.Map<LodgerPostDto>(lodgerViewModel));
                Lodgers.Add(_mapper.Map<LodgerViewModel>(newLodger));
            }
        });

        LodgerEditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedLodger != null)
            {
                var lodgerViewModel = await ShowLodgerDialog.Handle(SelectedLodger);
                if (lodgerViewModel != null)
                {
                    await _apiClient.PutLodgersAsync(SelectedLodger!.Id, _mapper.Map<LodgerPostDto>(lodgerViewModel));
                    _mapper.Map(lodgerViewModel, SelectedLodger);
                }
            }
        },
        this.WhenAnyValue(vm => vm.SelectedLodger).Select(_selected => _selected != null)
        );

        LodgerDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteLodgersAsync(SelectedLodger!.Id);
            Lodgers.Remove(SelectedLodger);
        },
        this.WhenAnyValue(vm => vm.SelectedLodger).Select(_selected => _selected != null)
        );

        /// <summary>
        /// BookedRooms ADD, EDIT and DELETE actions
        /// </summary>

        BroomsAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var broomsViewModel = await ShowBroomDialog.Handle(new BookedRoomsViewModel());
            if (broomsViewModel != null)
            {
                var newBroom = await _apiClient.PostBroomsAsync(_mapper.Map<BookedRoomsPostDto>(broomsViewModel));
                Brooms.Add(_mapper.Map<BookedRoomsViewModel>(newBroom));
            }
        });

        BroomsEditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedBroom != null)
            {
                var broomsViewModel = await ShowBroomDialog.Handle(SelectedBroom);
                if (broomsViewModel != null)
                {
                    await _apiClient.PutBroomsAsync(SelectedBroom!.Id, _mapper.Map<BookedRoomsPostDto>(broomsViewModel));
                    _mapper.Map(broomsViewModel, SelectedBroom);
                }
            }
        },
        this.WhenAnyValue(vm => vm.SelectedBroom).Select(_selected => _selected != null)
        );

        BroomsDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBroomsAsync(SelectedBroom!.Id);
            Brooms.Remove(SelectedBroom);
        },
        this.WhenAnyValue(vm => vm.SelectedBroom).Select(_selected => _selected != null)
        );

        /// <summary>
        /// Analytics
        /// </summary>

        InfoHotelsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var task = await ShowInfoHotels.Handle(new InfoHotelsViewModel());
        });

        InfoClientsInHotelCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var task = await ShowInfoClientsInHotel.Handle(new InfoClientsInHotelViewModel());
        });

        Top5MostBookedCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var task = await ShowTop5MostBooked.Handle(new Top5MostBookedViewModel());
        });

        AvailableRoomsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var task = await ShowAvailableRooms.Handle(new AvailableRoomsViewModel());
        });

        ClientsWithMostDaysCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var task = await ShowClientsWithMostDays.Handle(new ClientsWithMostDaysViewModel());
        });

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }
}
