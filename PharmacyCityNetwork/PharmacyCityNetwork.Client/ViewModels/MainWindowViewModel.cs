using AutoMapper;
using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

namespace PharmacyCityNetwork.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public ObservableCollection<ProductViewModel> Products { get; } = new();
    public ObservableCollection<GroupViewModel> Groups { get; } = new();
    public ObservableCollection<PharmacyViewModel> Pharmacys { get; } = new();
    //public ObservableCollection<PharmacyViewModel> Pharmacys { get; } = new();

    private ProductViewModel? _selectedProduct;
    public ProductViewModel? SelectedProduct
    {
        get => _selectedProduct;
        set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
    }
    private GroupViewModel? _selectedGroup;
    public GroupViewModel? SelectedGroup
    {
        get => _selectedGroup;
        set => this.RaiseAndSetIfChanged(ref _selectedGroup, value);
    }
    private PharmacyViewModel? _selectedPharmacy;
    public PharmacyViewModel? SelectedPharmacy
    {
        get => _selectedPharmacy;
        set => this.RaiseAndSetIfChanged(ref _selectedPharmacy, value);
    }
    public ReactiveCommand<Unit, Unit> OnAddCommandProduct { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandProduct { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandProduct { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandGroup { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandGroup { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandGroup { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandPharmacy { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandPharmacy { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandPharmacy { get; set; }

    public Interaction<ProductViewModel, ProductViewModel?> ShowProductDialog { get; set; }
    public Interaction<GroupViewModel, GroupViewModel?> ShowGroupDialog { get; set; }
    public Interaction<PharmacyViewModel, PharmacyViewModel?> ShowPharmacyDialog { get; set; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ProductViewModel, ProductViewModel?>();
        ShowGroupDialog = new Interaction<GroupViewModel, GroupViewModel?>();
        ShowPharmacyDialog = new Interaction<PharmacyViewModel, PharmacyViewModel?>();

        OnAddCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(new ProductViewModel());
            if (productViewModel != null)
            {
                var newProduct = _mapper.Map<ProductPostDto>(productViewModel);
                await _apiClient.AddProductAsync(newProduct);
                Products.Add(productViewModel);
            }
        });

        OnChangeCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
            var productViewModel = await ShowProductDialog.Handle(SelectedProduct!);
            if (productViewModel != null)
            {
                await _apiClient.UpdateProductAsync(SelectedProduct!.Id, _mapper.Map<ProductPostDto>(productViewModel));
                _mapper.Map(productViewModel, SelectedProduct);
            }
        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnDeleteCommandProduct = ReactiveCommand.CreateFromTask(async () =>
        {
                await _apiClient.DeleteProductAsync(SelectedProduct!.Id);
                Products.Remove(SelectedProduct);

        }, this.WhenAnyValue(vm => vm.SelectedProduct).Select(selectedProduct => selectedProduct != null));

        OnAddCommandGroup = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupViewModel = await ShowGroupDialog.Handle(new GroupViewModel());
            if (groupViewModel != null)
            {
                var newGroup = _mapper.Map<GroupPostDto>(groupViewModel);
                await _apiClient.AddGroupAsync(newGroup);
                Groups.Add(groupViewModel);
            }
        });

        OnChangeCommandGroup = ReactiveCommand.CreateFromTask(async () =>
        {
            var groupViewModel = await ShowGroupDialog.Handle(SelectedGroup!);
            if (groupViewModel != null)
            {
                await _apiClient.UpdateGroupAsync(SelectedGroup!.Id, _mapper.Map<GroupPostDto>(groupViewModel));
                _mapper.Map(groupViewModel, SelectedGroup);
            }
        }, this.WhenAnyValue(vm => vm.SelectedGroup).Select(selectedGroup => selectedGroup != null));

        OnDeleteCommandGroup = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteGroupAsync(SelectedGroup!.Id);
            Groups.Remove(SelectedGroup);

        }, this.WhenAnyValue(vm => vm.SelectedGroup).Select(selectedGroup => selectedGroup != null));

        OnAddCommandPharmacy = ReactiveCommand.CreateFromTask(async () =>
        {
            var pharmacyViewModel = await ShowPharmacyDialog.Handle(new PharmacyViewModel());
            if (pharmacyViewModel != null)
            {
                var newPharmacy = _mapper.Map<PharmacyPostDto>(pharmacyViewModel);
                await _apiClient.AddPharmacyAsync(newPharmacy);
                Pharmacys.Add(pharmacyViewModel);
            }
        });

        OnChangeCommandPharmacy = ReactiveCommand.CreateFromTask(async () =>
        {
            var pharmacyViewModel = await ShowPharmacyDialog.Handle(SelectedPharmacy!);
            if (pharmacyViewModel != null)
            {
                await _apiClient.UpdatePharmacyAsync(SelectedPharmacy!.Id, _mapper.Map<PharmacyPostDto>(pharmacyViewModel));
                _mapper.Map(pharmacyViewModel, SelectedPharmacy);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPharmacy).Select(selectedPharmacy => selectedPharmacy != null));

        OnDeleteCommandPharmacy = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePharmacyAsync(SelectedPharmacy!.Id);
            Pharmacys.Remove(SelectedPharmacy);

        }, this.WhenAnyValue(vm => vm.SelectedPharmacy).Select(selectedPharmacy => selectedPharmacy != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }

    private async void LoadAllAsync()
    {
        var products = await _apiClient.GetProductsAsync();
        foreach (var product in products) 
        {
            Products.Add(_mapper.Map<ProductViewModel>(product));
        }
        var groups = await _apiClient.GetGroupsAsync();
        foreach (var group in groups)
        {
            Groups.Add(_mapper.Map<GroupViewModel>(group));
        }
        var pharmacys = await _apiClient.GetPharmacysAsync();
        foreach (var pharmacy in pharmacys)
        {
            Pharmacys.Add(_mapper.Map<PharmacyViewModel>(pharmacy));
        }
    }
}