using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Fabrics.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddFabricCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeFabricCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteFabricCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddProviderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeProviderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteProviderCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddShipmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeShipmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteShipmentCommand { get; set; }

    public ObservableCollection<FabricViewModel> Fabrics { get; } = new();
    public ObservableCollection<ProviderViewModel> Providers { get; } = new();
    public ObservableCollection<ShipmentViewModel> Shipments { get; } = new();

    private FabricViewModel? _selectedFabric;
    private ProviderViewModel? _selectedProvider;
    private ShipmentViewModel? _selectedShipment;

    public FabricViewModel? SelectedFabric
    {
        get => _selectedFabric;
        set => this.RaiseAndSetIfChanged(ref _selectedFabric, value);
    }

    public ProviderViewModel? SelectedProvider
    {
        get => _selectedProvider;
        set => this.RaiseAndSetIfChanged(ref _selectedProvider, value);
    }

    public ShipmentViewModel? SelectedShipment
    {
        get => _selectedShipment;
        set => this.RaiseAndSetIfChanged(ref _selectedShipment, value);
    }

    public Interaction<FabricViewModel, FabricViewModel?> ShowFabricDialog { get; }
    public Interaction<ProviderViewModel, ProviderViewModel?> ShowProviderDialog { get; }
    public Interaction<ShipmentViewModel, ShipmentViewModel?> ShowShipmentDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowFabricDialog = new Interaction<FabricViewModel, FabricViewModel?>();

        OnAddFabricCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var fabricViewmodel = await ShowFabricDialog.Handle(new FabricViewModel());
            if (fabricViewmodel != null)
            {
                var newFabric = await _apiClient.AddFabricAsync(_mapper.Map<FabricPostDto>(fabricViewmodel));
                Fabrics.Add(_mapper.Map<FabricViewModel>(newFabric));
            }
        });

        OnChangeFabricCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var fabricViewmodel = await ShowFabricDialog.Handle(SelectedFabric!);
            if (fabricViewmodel != null)
            {
                await _apiClient.UpdateFabricAsync(SelectedFabric!.Id, _mapper.Map<FabricPostDto>(fabricViewmodel));
                _mapper.Map(fabricViewmodel, SelectedFabric);
            }
        }, this.WhenAnyValue(vm => vm.SelectedFabric).Select(selectFabric => selectFabric != null));

        OnDeleteFabricCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteFabricAsync(SelectedFabric!.Id);
            Fabrics.Remove(SelectedFabric);
        }, this.WhenAnyValue(vm => vm.SelectedFabric).Select(selectFabric => selectFabric != null));

        ShowProviderDialog = new Interaction<ProviderViewModel, ProviderViewModel?>();

        OnAddProviderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var providerViewmodel = await ShowProviderDialog.Handle(new ProviderViewModel());
            if (providerViewmodel != null)
            {
                var newProvider = await _apiClient.AddProviderAsync(_mapper.Map<ProviderPostDto>(providerViewmodel));
                Providers.Add(_mapper.Map<ProviderViewModel>(newProvider));
            }
        });

        OnChangeProviderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var providerViewmodel = await ShowProviderDialog.Handle(SelectedProvider!);
            if (providerViewmodel != null)
            {
                await _apiClient.UpdateProviderAsync(SelectedProvider!.Id, _mapper.Map<ProviderPostDto>(providerViewmodel));
                _mapper.Map(providerViewmodel, SelectedProvider);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProvider).Select(selectProvider => selectProvider != null));

        OnDeleteProviderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteProviderAsync(SelectedProvider!.Id);
            Providers.Remove(SelectedProvider);
        }, this.WhenAnyValue(vm => vm.SelectedProvider).Select(selectProvider => selectProvider != null));

        ShowShipmentDialog = new Interaction<ShipmentViewModel, ShipmentViewModel?>();

        OnAddShipmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var shipmentViewmodel = await ShowShipmentDialog.Handle(new ShipmentViewModel());
            if (shipmentViewmodel != null)
            {
                var newShipment = await _apiClient.AddShipmentAsync(_mapper.Map<ShipmentPostDto>(shipmentViewmodel));
                Shipments.Add(_mapper.Map<ShipmentViewModel>(newShipment));
            }
        });

        OnChangeShipmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var shipmentViewmodel = await ShowShipmentDialog.Handle(SelectedShipment!);
            if (shipmentViewmodel != null)
            {
                await _apiClient.UpdateShipmentAsync(SelectedShipment!.Id, _mapper.Map<ShipmentPostDto>(shipmentViewmodel));
                _mapper.Map(shipmentViewmodel, SelectedShipment);
            }
        }, this.WhenAnyValue(vm => vm.SelectedShipment).Select(selectShipment => selectShipment != null));

        OnDeleteShipmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteShipmentAsync(SelectedShipment!.Id);
            Shipments.Remove(SelectedShipment);
        }, this.WhenAnyValue(vm => vm.SelectedShipment).Select(selectShipment => selectShipment != null));

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

    private async void LoadDataAsync()
    {
        var fabrics = await _apiClient.GetFabricAsync();
        foreach (var fabric in fabrics)
        {
            Fabrics.Add(_mapper.Map<FabricViewModel>(fabric));
        }
        var providers = await _apiClient.GetProviderAsync();
        foreach (var provider in providers)
        {
            Providers.Add(_mapper.Map<ProviderViewModel>(provider));
        }
        
        var shipments = await _apiClient.GetShipmentAsync();
        foreach (var shipment in shipments)
        {
            Shipments.Add(_mapper.Map<ShipmentViewModel>(shipment));
        }
    }
    
}
