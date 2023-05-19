using AutoMapper;
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

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;
    
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }
    
    public ReactiveCommand<Unit, Unit> OnAddSupplierCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeSupplierCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteSupplierCommand { get; set; }
    
    public Interaction<EnterpriseViewModel, EnterpriseViewModel?> ShowEnterpriseDialog { get; } 
    public Interaction<SupplierViewModel, SupplierViewModel?> ShowSupplierDialog { get; }

    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowEnterpriseDialog = new Interaction<EnterpriseViewModel, EnterpriseViewModel?>();
        ShowSupplierDialog = new Interaction<SupplierViewModel, SupplierViewModel?>();

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
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(new EnterpriseViewModel());
            if (enterpriseViewModel != null)
            {
                await _apiClient.DeleteEnterpriseAsync(SelectedEnterprise!.EnterpriseID);
                Enterprises.Remove(SelectedEnterprise);
            }
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
            var supplierViewModel = await ShowSupplierDialog.Handle(new SupplierViewModel());
            if (supplierViewModel != null)
            {
                await _apiClient.DeleteSupplierAsync(SelectedSupplier!.SupplierID);
                Suppliers.Remove(SelectedSupplier);
            }
        }, this.WhenAnyValue(vm => vm.SelectedSupplier).Select(selectSupplier => selectSupplier != null));

        RxApp.MainThreadScheduler.Schedule(LoadEnterprisesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSupplierAsync);
    }

    private async void LoadEnterprisesAsync()
    {
        var enterprises = await _apiClient.GetEnterpriseAsync();
        foreach (var enterprise in enterprises)
        {
            Enterprises.Add(_mapper.Map<EnterpriseViewModel>(enterprise));
        }

    }
    private async void LoadSupplierAsync()
    {

        var suppliers = await _apiClient.GetSupplierAsync();
        foreach (var supplier in suppliers)
        {
            Suppliers.Add(_mapper.Map<SupplierViewModel>(supplier));
        }
    }
}
