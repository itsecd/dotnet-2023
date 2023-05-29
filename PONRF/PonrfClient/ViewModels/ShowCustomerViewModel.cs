using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class ShowCustomerViewModel : ViewModelBase
{
    public ObservableCollection<CustomerViewModel> Customers { get; } = new();

    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set => this.RaiseAndSetIfChanged(ref _selectedCustomer, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCustomerCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCustomerCommand { get; set; }

    public Interaction<CustomerViewModel, CustomerViewModel?> ShowCustomerDialog { get; }

    public ShowCustomerViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();

        OnAddCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(new CustomerViewModel());
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.AddCustomerAsync(newCustomer);
                Customers.Add(customerViewModel);
                Customers.Clear();
                LoadCustomerAsync();
            }
        });

        OnChangeCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var customerViewModel = await ShowCustomerDialog.Handle(SelectedCustomer!);
            if (customerViewModel != null)
            {
                var newCustomer = _mapper.Map<CustomerPostDto>(customerViewModel);
                await _apiClient.UpdateCustomerAsync(SelectedCustomer!.Id, newCustomer);
                _mapper.Map(customerViewModel, SelectedCustomer);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        OnDeleteCustomerCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCustomerAsync(SelectedCustomer!.Id);
            Customers.Remove(SelectedCustomer);
        }, this.WhenAnyValue(vm => vm.SelectedCustomer).Select(selectedCustomer => selectedCustomer != null));

        RxApp.MainThreadScheduler.Schedule(LoadCustomerAsync);
    }

    private async void LoadCustomerAsync()
    {
        var customers = await _apiClient.GetCustomerAsync();
        foreach (var customer in customers)
        {
            Customers.Add(_mapper.Map<CustomerViewModel>(customer));
        }
    }
}
