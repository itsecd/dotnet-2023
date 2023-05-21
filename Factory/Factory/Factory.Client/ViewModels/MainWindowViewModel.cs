using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Factory.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<EnterpriseViewModel> Enterprises { get; } = new();
    public ObservableCollection<SupplierViewModel> Suppliers { get; } = new();
    public ObservableCollection<SupplyViewModel> Supplies { get; } = new();
    public ObservableCollection<TypeIndustryViewModel> TypeIndustries { get; } = new();
    public ObservableCollection<OwnershipFormViewModel> OwnershipForms { get; } = new();

    private EnterpriseViewModel? _selectedEnterprise;
    public EnterpriseViewModel? SelectedEnterprise
    {
        get => _selectedEnterprise;
        set => this.RaiseAndSetIfChanged(ref _selectedEnterprise, value);
    }

    private SupplierViewModel? _selectedSupplier;
    public SupplierViewModel? SelectedSupplier
    {
        get => _selectedSupplier;
        set => this.RaiseAndSetIfChanged(ref _selectedSupplier, value);
    }

    private SupplyViewModel? _selectedSupply;
    public SupplyViewModel? SelectedSupply
    {
        get => _selectedSupply;
        set => this.RaiseAndSetIfChanged(ref _selectedSupply, value);
    }

    private TypeIndustryViewModel? _selectedTypeIndustry;
    public TypeIndustryViewModel? SelectedTypeIndustry
    {
        get => _selectedTypeIndustry;
        set => this.RaiseAndSetIfChanged(ref _selectedTypeIndustry, value);
    }

    private OwnershipFormViewModel? _selectedOwnershipForm;
    public OwnershipFormViewModel? SelectedOwnershipForm
    {
        get => _selectedOwnershipForm;
        set => this.RaiseAndSetIfChanged(ref _selectedOwnershipForm, value);
    }
    
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> OnAddSupplierCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSupplierCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSupplierCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSupplyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSupplyCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSupplyCommand { get; set; }

    public Interaction<EnterpriseViewModel, EnterpriseViewModel?> ShowEnterpriseDialog { get; } 
    public Interaction<SupplierViewModel, SupplierViewModel?> ShowSupplierDialog { get; }
    public Interaction<SupplyViewModel, SupplyViewModel?> ShowSupplyDialog { get; }
    public Interaction<TypeIndustryViewModel, TypeIndustryViewModel?> ShowTypeIndustryDialog { get; }

    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowEnterpriseDialog = new Interaction<EnterpriseViewModel, EnterpriseViewModel?>();
        ShowSupplierDialog = new Interaction<SupplierViewModel, SupplierViewModel?>();
        ShowSupplyDialog = new Interaction<SupplyViewModel, SupplyViewModel?>();
       // ShowTypeIndustryDialog = new Interaction<TypeIndustryViewModel, TypeIndustryViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(new EnterpriseViewModel());
            if(enterpriseViewModel != null)
            {
                var newEnterprise = _mapper.Map<EnterprisePostDto>(enterpriseViewModel);
                await _apiClient.AddEnterpriseAsync(newEnterprise);
                Enterprises.Add(enterpriseViewModel);
            }
        });
        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(SelectedEnterprise!);
            if (enterpriseViewModel != null)
            {
                var newEnterprise = _mapper.Map<EnterprisePostDto>(enterpriseViewModel);
                await _apiClient.UpdateEnterpriseAsync(SelectedEnterprise!.EnterpriseID, newEnterprise);
                _mapper.Map (enterpriseViewModel, SelectedEnterprise);
            }
        }, this.WhenAnyValue(vm => vm.SelectedEnterprise).Select(selectEnterprise => selectEnterprise != null));
        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteEnterpriseAsync(SelectedEnterprise!.EnterpriseID);
            Enterprises.Remove(SelectedEnterprise);
        }, this.WhenAnyValue(vm => vm.SelectedEnterprise).Select(selectEnterprise => selectEnterprise != null));

        OnAddSupplierCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplierViewModel = await ShowSupplierDialog!.Handle(new SupplierViewModel());
            if (supplierViewModel != null)
            {
                var newSupplier = _mapper.Map<SupplierPostDto>(supplierViewModel);
                await _apiClient.AddSupplierAsync(newSupplier);
                Suppliers.Add(supplierViewModel);
            }
        });
        OnChangeSupplierCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplierViewModel = await ShowSupplierDialog!.Handle(SelectedSupplier!);
            if (supplierViewModel != null)
            {
                var newSupplier = _mapper.Map<SupplierPostDto>(supplierViewModel);
                await _apiClient.UpdateSupplierAsync(SelectedSupplier!.SupplierID, newSupplier);
                _mapper.Map(supplierViewModel, SelectedSupplier);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSupplier).Select(selectSupplier => selectSupplier != null));
        OnDeleteSupplierCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSupplierAsync(SelectedSupplier!.SupplierID);
            Suppliers.Remove(SelectedSupplier);

        }, this.WhenAnyValue(vm => vm.SelectedSupplier).Select(selectSupplier => selectSupplier != null));

        OnAddSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplyViewModel = await ShowSupplyDialog!.Handle(new SupplyViewModel());
            if (supplyViewModel != null)
            {
                var newSupply = _mapper.Map<SupplyPostDto>(supplyViewModel);
                await _apiClient.AddSupplyAsync(newSupply);
                Supplies.Add(supplyViewModel);
            }
        });
        OnChangeSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var supplyViewModel = await ShowSupplyDialog!.Handle(SelectedSupply!);
            if (supplyViewModel != null)
            {
                var newSupply = _mapper.Map<SupplyPostDto>(supplyViewModel);
                await _apiClient.UpdateSupplyAsync(SelectedSupply!.SupplyID, newSupply);
                _mapper.Map(supplyViewModel, SelectedSupply);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSupply).Select(selectSupply => selectSupply != null));
        OnDeleteSupplyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteSupplyAsync(SelectedSupply!.SupplyID);
            Supplies.Remove(SelectedSupply);

        }, this.WhenAnyValue(vm => vm.SelectedSupply).Select(selectSupply => selectSupply != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }

    private async void LoadAllAsync()
    {
        var enterprises = await _apiClient.GetEnterpriseAsync();
        foreach (var enterprise in enterprises)
        {
            Enterprises.Add(_mapper.Map<EnterpriseViewModel>(enterprise));
        }

        var suppliers = await _apiClient.GetSupplierAsync();
        foreach (var supplier in suppliers)
        {
            Suppliers.Add(_mapper.Map<SupplierViewModel>(supplier));
        }

        var supplies = await _apiClient.GetSupplyAsync();
        foreach (var supply in supplies)
        {
            Supplies.Add(_mapper.Map<SupplyViewModel>(supply));
        }

        var types = await _apiClient.GetTypeIndustryAsync();
        foreach (var type in types)
        {
            TypeIndustries.Add(_mapper.Map<TypeIndustryViewModel>(type));
        }

        var forms = await _apiClient.GetOwnershipFormAsync();
        foreach (var form in forms)
        {
            OwnershipForms.Add(_mapper.Map<OwnershipFormViewModel>(form));
        }
    }
}
