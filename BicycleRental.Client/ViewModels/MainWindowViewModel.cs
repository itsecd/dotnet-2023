using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace BicycleRental.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BicycleViewModel> Bicycles { get; } = new();
    public ObservableCollection<CustomerViewModel> Customers { get; } = new();
    public ObservableCollection<BicycleRentalViewModel> Rentals { get; } = new();
    public ObservableCollection<BicycleTypeViewModel> Types { get; } = new();
    public ObservableCollection<BicycleViewModel> SportBicycles { get; } = new();


    private BicycleViewModel? _selectedBicycle;
    public BicycleViewModel? SelectedBicycle
    {
        get => _selectedBicycle;
        set => this.RaiseAndSetIfChanged(ref _selectedBicycle, value);
    }   

    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set => this.RaiseAndSetIfChanged(ref _selectedCustomer, value);
    }
   

    private BicycleRentalViewModel? _selectedRental;
    public BicycleRentalViewModel? SelectedRental
    {
        get => _selectedRental;
        set => this.RaiseAndSetIfChanged(ref _selectedRental, value);
    }

    private BicycleTypeViewModel? _selectedType;
    public BicycleTypeViewModel? SelectedType
    {
        get => _selectedType;
        set => this.RaiseAndSetIfChanged(ref _selectedType, value);
    }

   
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddBicycleCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeBicycleCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteBicycleCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCustomerCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddRentalCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeRentalCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteRentalCommand { get; set; }

    public Interaction<BicycleViewModel, BicycleViewModel?> ShowBicycleDialog { get; }

    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }

    public Interaction<BicycleRentalViewModel, BicycleRentalViewModel?> ShowRentalDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBicycleDialog = new Interaction<BicycleViewModel, BicycleViewModel?>();

        OnAddBicycleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bicycleViewModel = await ShowBicycleDialog.Handle(new BicycleViewModel());
            if (bicycleViewModel != null)
            {
                var newBicycle = _mapper.Map<BicyclePostDto>(bicycleViewModel);
                await _apiClient.AddBicycleAsync(newBicycle);
                Bicycles.Add(bicycleViewModel);
                
            }
        });

        OnChangeBicycleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bicycleViewModel = await ShowBicycleDialog.Handle(SelectedBicycle!);
            if (bicycleViewModel != null)
            {
                await _apiClient.UpdateBicycleAsync(SelectedBicycle!.SerialNumber, _mapper.Map<BicyclePostDto>(bicycleViewModel));
                _mapper.Map(bicycleViewModel, SelectedBicycle);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBicycle).Select(selectBicycle => selectBicycle != null));

        OnDeleteBicycleCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBicycleAsync(SelectedBicycle!.SerialNumber);
            Bicycles.Remove(SelectedBicycle);

        }, this.WhenAnyValue(vm => vm.SelectedBicycle).Select(selectBicycle => selectBicycle != null));


        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();

        OnAddCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(new CustomerViewModel());
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.AddCustomerAsync(newCustomer);
                Customers.Add(customerViewModel);
                
            }
        });

        OnChangeCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(SelectedCustomer!);
            if (customerViewModel != null)
            {
                await _apiClient.UpdateCustomerAsync(SelectedCustomer!.Id, _mapper.Map<CustomerPostDto>(customerViewModel));
                _mapper.Map(customerViewModel, SelectedCustomer);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectCustomer => selectCustomer != null));

        OnDeleteCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCustomerAsync(SelectedCustomer!.Id);
            Customers.Remove(SelectedCustomer);
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectCustomer => selectCustomer != null));


        ShowRentalDialog = new Interaction<BicycleRentalViewModel, BicycleRentalViewModel?>();

        OnAddRentalCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalViewModel = await ShowRentalDialog.Handle(new BicycleRentalViewModel());
            if (rentalViewModel != null)
            {
                var newRental = _mapper.Map<RentalPostDto>(rentalViewModel);
                await _apiClient.AddRentalAsync(newRental);
                Rentals.Add(rentalViewModel);
               
            }
        });

        OnChangeRentalCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var rentalViewModel = await ShowRentalDialog.Handle(SelectedRental!);
            if (rentalViewModel != null)
            {
                await _apiClient.UpdateRentalAsync(SelectedRental!.RentalId, _mapper.Map<RentalPostDto>(rentalViewModel));
                _mapper.Map(rentalViewModel, SelectedRental);
            }
        }, this.WhenAnyValue(vm => vm.SelectedRental).Select(selectRental => selectRental != null));

        OnDeleteRentalCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteRentalAsync(SelectedRental!.RentalId);
            Rentals.Remove(SelectedRental);
        }, this.WhenAnyValue(vm => vm.SelectedRental).Select(selectRental => selectRental != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }

    private async void LoadAllAsync()
    {
        var bicycles = await _apiClient.GetBicyclesAsync();
        foreach (var bicycle in bicycles)
        {
            Bicycles.Add(_mapper.Map<BicycleViewModel>(bicycle));
        }

        var customers = await _apiClient.GetCustomerAsync();
        foreach (var customer in customers)
        {
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
        }

        var rentals = await _apiClient.GetRentalsAsync();
        foreach (var rental in rentals)
        {
            Rentals.Add(_mapper.Map<BicycleRentalViewModel>(rental));
        }

        var types = await _apiClient.GetTypesAsync();
        foreach (var type in types)
        {
            Types.Add(_mapper.Map<BicycleTypeViewModel>(type));
        }

        var sports = await _apiClient.GetSportAsync();
        foreach (var sport in sports)
        {
            SportBicycles.Add(_mapper.Map<BicycleViewModel>(sport));
        }
    }
}
