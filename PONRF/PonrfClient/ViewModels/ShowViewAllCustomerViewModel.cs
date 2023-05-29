using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class ShowViewAllCustomerViewModel : ViewModelBase
{
    public ObservableCollection<CustomerViewModel> ViewAllCustomers { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> ShowViewAllCustomers { get; set; }

    public Interaction<CustomerViewModel, CustomerViewModel?> ShowViewAllCustomerDialog { get; }

    public ShowViewAllCustomerViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowViewAllCustomerDialog = new Interaction<CustomerViewModel, CustomerViewModel?>();

        ShowViewAllCustomers = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestCustomer = await _apiClient.ViewAllCustomers();
            foreach (var customer in requestCustomer)
            {
                ViewAllCustomers.Add(_mapper.Map<CustomerViewModel>(customer));
            }
        });
    }
}
