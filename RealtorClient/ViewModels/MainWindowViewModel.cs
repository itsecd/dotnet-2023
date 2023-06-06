using System.Collections.ObjectModel;
using AutoMapper;
using Splat;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData;

namespace RealtorClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ObservableCollection<HouseViewModel> Houses { get; } = new();
    public ObservableCollection<ClientViewModel> Clients { get; } = new();
    public ObservableCollection<ApplicationViewModel> Applications { get; } = new();
    public ObservableCollection<ApplicationHasHouseViewModel> ApplicationHasHouses { get; } = new();
    public ObservableCollection<BuyersViewModel> Buyers { get; } = new();
    private HouseViewModel? _selectedHouse;
    public HouseViewModel? SelectedHouse
    {
        get => _selectedHouse;
        set => this.RaiseAndSetIfChanged(ref _selectedHouse, value);
    }
    private ApplicationViewModel? _selectedApplication;
    public ApplicationViewModel? SelectedApplication
    {
        get => _selectedApplication;
        set => this.RaiseAndSetIfChanged(ref _selectedApplication, value);
    }

    private ClientViewModel? _selectedClient;
    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }
    private ApplicationHasHouseViewModel? _selectedApplicationHasHouse;
    public ApplicationHasHouseViewModel? SelectedApplicationHasHouse
    {
        get => _selectedApplicationHasHouse;
        set => this.RaiseAndSetIfChanged(ref _selectedApplicationHasHouse, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeApplicationCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteApplicationCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddHouseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeHouseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteHouseCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteClientCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddApplicationHasHouseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeApplicationHasHouseCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteApplicationHasHouseCommand { get; set; }

    public Interaction<HouseViewModel, HouseViewModel?> ShowHouseDialog { get; }

    public Interaction<ApplicationViewModel, ApplicationViewModel?> ShowApplicationDialog;

    public Interaction<ApplicationViewModel, ApplicationViewModel?> ShowRApplicationDialog { get; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; }
    public Interaction<ApplicationHasHouseViewModel, ApplicationHasHouseViewModel?> ShowApplicationHasHouseDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowHouseDialog = new Interaction<HouseViewModel, HouseViewModel?>();
        ShowApplicationDialog = new Interaction<ApplicationViewModel, ApplicationViewModel?>();
        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();
        ShowApplicationHasHouseDialog = new Interaction<ApplicationHasHouseViewModel, ApplicationHasHouseViewModel?>();

        OnAddHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var houseViewModel = await ShowHouseDialog.Handle(new HouseViewModel());
            if (houseViewModel != null)
            {
                var newHouse = _mapper.Map<HousePostDto>(houseViewModel);
                await _apiClient.AddHouseAsync(newHouse);
                Houses.Add(houseViewModel);
                Houses.Clear();
                Applications.Clear();
                Clients.Clear();
                ApplicationHasHouses.Clear();
                Buyers.Clear();
                LoadAsync();
            }
        });
        OnChangeHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var houseViewModel = await ShowHouseDialog.Handle(SelectedHouse!);
            if (houseViewModel != null)
            {
                await _apiClient.UpdateHouseAsync(SelectedHouse!.Id, _mapper.Map<HousePostDto>(houseViewModel));
                _mapper.Map(houseViewModel, SelectedHouse);
            }
        }, this.WhenAnyValue(vm => vm.SelectedHouse).Select(selectHouse => selectHouse != null));
        OnDeleteHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteHouseAsync(SelectedHouse!.Id);
            Houses.Remove(SelectedHouse);
        }, this.WhenAnyValue(vm => vm.SelectedHouse).Select(selectHouse => selectHouse != null));


        OnAddApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var applicationPointViewModel = await ShowApplicationDialog.Handle(new ApplicationViewModel());
            if (applicationPointViewModel != null)
            {
                var newApplication = _mapper.Map<ApplicationPostDto>(applicationPointViewModel);
                await _apiClient.AddApplicationAsync(newApplication);
                Applications.Add(applicationPointViewModel);
                Houses.Clear();
                Applications.Clear();
                Clients.Clear();
                ApplicationHasHouses.Clear();
                Buyers.Clear();
                LoadAsync();
            }
        });
        OnChangeApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var applicationPointViewModel = await ShowApplicationDialog.Handle(SelectedApplication!);
            if (applicationPointViewModel != null)
            {
                await _apiClient.UpdateApplicationAsync(SelectedApplication!.Id, _mapper.Map<ApplicationPostDto>(applicationPointViewModel));
                _mapper.Map(applicationPointViewModel, SelectedApplication);
            }
        }, this.WhenAnyValue(vm => vm.SelectedApplication).Select(selectApplication => selectApplication != null));
        OnDeleteApplicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteApplicationAsync(SelectedApplication!.Id);
            Applications.Remove(SelectedApplication);
        }, this.WhenAnyValue(vm => vm.SelectedApplication).Select(selectApplication => selectApplication != null));

        OnAddClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                var newClient = _mapper.Map<ClientPostDto>(clientViewModel);
                await _apiClient.AddClientAsync(newClient);
                Clients.Add(clientViewModel);
                Houses.Clear();
                Applications.Clear();
                Clients.Clear();
                ApplicationHasHouses.Clear();
                Buyers.Clear();
                LoadAsync();
            }
        });
        OnChangeClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientAsync(SelectedClient!.Id, _mapper.Map<ClientPostDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectClient => selectClient != null));
        OnDeleteClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteClientAsync(SelectedClient!.Id);
            Clients.Remove(SelectedClient);
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectClient => selectClient != null));

        OnAddApplicationHasHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var applicationHasHouseViewModel = await ShowApplicationHasHouseDialog.Handle(new ApplicationHasHouseViewModel());
            if (applicationHasHouseViewModel != null)
            {
                var newApplicationHasHouse = _mapper.Map<ApplicationHasHouseDto>(applicationHasHouseViewModel);
                await _apiClient.AddApplicationHasHouseAsync(newApplicationHasHouse);
                ApplicationHasHouses.Add(applicationHasHouseViewModel);
                Houses.Clear();
                Applications.Clear();
                Clients.Clear();
                ApplicationHasHouses.Clear();
               Buyers.Clear();
                LoadAsync();
            }
        });
        OnChangeApplicationHasHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var applicationHasHouseViewModel = await ShowApplicationHasHouseDialog.Handle(SelectedApplicationHasHouse!);
            if (applicationHasHouseViewModel != null)
            {
                await _apiClient.UpdateApplicationHasHouseAsync(SelectedApplicationHasHouse!.Id, _mapper.Map<ApplicationHasHouseDto>(applicationHasHouseViewModel));
                _mapper.Map(applicationHasHouseViewModel, SelectedApplicationHasHouse);
            }
        }, this.WhenAnyValue(vm => vm.SelectedApplicationHasHouse).Select(selectApplicationHasHouse => selectApplicationHasHouse != null));
        OnDeleteApplicationHasHouseCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteApplicationHasHouseAsync(SelectedApplicationHasHouse!.Id);
            ApplicationHasHouses.Remove(SelectedApplicationHasHouse);
        }, this.WhenAnyValue(vm => vm.SelectedApplicationHasHouse).Select(selectApplicationHasHouse => selectApplicationHasHouse != null));
        RxApp.MainThreadScheduler.Schedule(LoadAsync);
    }

    private async void LoadAsync()
    {
        var houses = await _apiClient.GetHouseAsync();
        foreach (var house in houses)
        {
            Houses.Add(_mapper.Map<HouseViewModel>(house));
        }

        var applications = await _apiClient.GetApplicationAsync();
        foreach (var application in applications)
        {
           Applications.Add(_mapper.Map<ApplicationViewModel>(application));
        }

        var clients = await _apiClient.GetClientAsync();
        foreach (var client in clients)
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }

        var applicationHasHouses = await _apiClient.GetApplicationHasHouseAsync();
        foreach (var applicationHasHouse in applicationHasHouses)
        {
            ApplicationHasHouses.Add(_mapper.Map<ApplicationHasHouseViewModel>(applicationHasHouse));
        }

        var buyers = await _apiClient.GetBuyers();
        foreach(var buyer in buyers)
        {
            Buyers.Add(_mapper.Map<BuyersViewModel>(buyer));

        }

    }
}
