using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace BikeRental.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<BikeViewModel> Bikes { get; } = new();
    public ObservableCollection<BikeTypeViewModel> BikeTypes { get; } = new();
    public ObservableCollection<ClientViewModel> Clients { get; } = new();
    public ObservableCollection<RentRecordViewModel> RentRecords { get; } = new();
    public ObservableCollection<BikeViewModel> SportBikes { get; } = new();


    private BikeViewModel? _selectedBike;
    public BikeViewModel? SelectedBike
    {
        get => _selectedBike;
        set => this.RaiseAndSetIfChanged(ref _selectedBike, value);
    }

    private BikeTypeViewModel? _selectedBikeType;
    public BikeTypeViewModel? SelectedBikeType
    {
        get => _selectedBikeType;
        set => this.RaiseAndSetIfChanged(ref _selectedBikeType, value);
    }

    private ClientViewModel? _selectedClient;
    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }

    private RentRecordViewModel? _selectedRentRecord;
    public RentRecordViewModel? SelectedRentRecord
    {
        get => _selectedRentRecord;
        set => this.RaiseAndSetIfChanged(ref _selectedRentRecord, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddBikeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeBikeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBikeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteClientCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRentRecordCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeRentRecordCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteRentRecordCommand { get; set; }

    public Interaction<BikeViewModel, BikeViewModel?> ShowBikeDialog { get; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; }
    public Interaction<RentRecordViewModel, RentRecordViewModel?> ShowRentRecordDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBikeDialog = new Interaction<BikeViewModel, BikeViewModel?>();
        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();
        ShowRentRecordDialog = new Interaction<RentRecordViewModel, RentRecordViewModel?>();

        OnAddBikeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bikeViewModel = await ShowBikeDialog.Handle(new BikeViewModel());
            if (bikeViewModel != null)
            {
                var newBike = await _apiClient.AddBikeAsync(_mapper.Map<BikeSetDto>(bikeViewModel));
                Bikes.Add(_mapper.Map<BikeViewModel>(newBike));
            }
        });

        OnChangeBikeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bikeViewModel = await ShowBikeDialog.Handle(SelectedBike!);
            if (bikeViewModel != null)
            {
                await _apiClient.UpdateBikeAsync(SelectedBike!.Id, _mapper.Map<BikeSetDto>(bikeViewModel));
                _mapper.Map(bikeViewModel, SelectedBike);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBike).Select(selectedBike => selectedBike != null));

        OnDeleteBikeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBikeAsync(SelectedBike!.Id);
            Bikes.Remove(SelectedBike);
        }, this.WhenAnyValue(vm => vm.SelectedBike).Select(selectedBike => selectedBike != null));

        OnAddClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                var newClient = await _apiClient.AddClientAsync(_mapper.Map<ClientSetDto>(clientViewModel));
                Clients.Add(_mapper.Map<ClientViewModel>(newClient));
            }
        });

        OnChangeClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientAsync(SelectedClient!.Id, _mapper.Map<ClientSetDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        OnDeleteClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteClientAsync(SelectedClient!.Id);
            Clients.Remove(SelectedClient);
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        OnAddRentRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentRecordViewModel = await ShowRentRecordDialog.Handle(new RentRecordViewModel());
            if (rentRecordViewModel != null)
            {
                var newRentRecord = await _apiClient.AddRentRecordAsync(_mapper.Map<RentRecordSetDto>(rentRecordViewModel));
                RentRecords.Add(_mapper.Map<RentRecordViewModel>(newRentRecord));
            }
        });

        OnChangeRentRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentRecordViewModel = await ShowRentRecordDialog.Handle(SelectedRentRecord!);
            if (rentRecordViewModel != null)
            {
                await _apiClient.UpdateRentRecordAsync(SelectedRentRecord!.Id, _mapper.Map<RentRecordSetDto>(rentRecordViewModel));
                _mapper.Map(rentRecordViewModel, SelectedRentRecord);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRentRecord).Select(selectedRentRecord => selectedRentRecord != null));

        OnDeleteRentRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentRecordAsync(SelectedRentRecord!.Id);
            RentRecords.Remove(SelectedRentRecord);
        }, this.WhenAnyValue(vm => vm.SelectedRentRecord).Select(selectedRentRecord => selectedRentRecord != null));

        RxApp.MainThreadScheduler.Schedule(LoadBikeTypesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadBikesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadClientsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadRentRecordsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSportBikesAsync);
    }

    private async void LoadBikeTypesAsync()
    {
        var bikeTypes = await _apiClient.GetBikeTypesAsync();
        foreach (var bikeType in bikeTypes)
        {
            BikeTypes.Add(_mapper.Map<BikeTypeViewModel>(bikeType));
        }
    }

    private async void LoadBikesAsync()
    {
        var bikes = await _apiClient.GetBikesAsync();
        foreach (var bike in bikes)
        {
            Bikes.Add(_mapper.Map<BikeViewModel>(bike));
        }
    }

    private async void LoadClientsAsync()
    {
        var clients = await _apiClient.GetClientsAsync();
        foreach (var client in clients)
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }
    }

    private async void LoadRentRecordsAsync()
    {
        var rentRecords = await _apiClient.GetRentRecordsAsync();
        foreach (var rentRecord in rentRecords)
        {
            RentRecords.Add(_mapper.Map<RentRecordViewModel>(rentRecord));
        }
    }

    private async void LoadSportBikesAsync()
    {
        var bikes = await _apiClient.GetSportBikesAsync();
        foreach (var bike in bikes)
        {
            SportBikes.Add(_mapper.Map<BikeViewModel>(bike));
        }
    }
}
