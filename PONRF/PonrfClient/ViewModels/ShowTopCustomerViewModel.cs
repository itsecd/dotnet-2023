using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class ShowTopCustomerViewModel : ViewModelBase
{
    public ObservableCollection<TopCustomerViewModel> TopCustomers { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> ShowTopCustomer { get; set; }

    public Interaction<TopCustomerViewModel, TopCustomerViewModel?> ShowTopCustomerDialog { get; }

    public ShowTopCustomerViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowTopCustomerDialog = new Interaction<TopCustomerViewModel, TopCustomerViewModel?>();

        ShowTopCustomer = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestCustomer = await _apiClient.TopCustomer();
            foreach (var customer in requestCustomer)
            {
                TopCustomers.Add(_mapper.Map<TopCustomerViewModel>(customer));
            }
        });
    }
}
