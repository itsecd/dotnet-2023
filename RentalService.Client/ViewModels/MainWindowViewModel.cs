using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace RentalService.Client.ViewModels;

using RentalService.Client;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ClientViewModel> Clients { get; } = new();

    private ClientViewModel? _selectedClient;
    public ClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }
    
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    
    public ReactiveCommand<Unit, Unit> OnAddClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditClientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteClientCommand { get; set; }
    public Interaction<ClientViewModel, ClientViewModel?> ShowClientDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        
        ShowClientDialog = new Interaction<ClientViewModel, ClientViewModel?>();
        OnAddClientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new ClientViewModel());
            if (clientViewModel != null)
            {
                var newClient = await _apiClient.AddClientsAsync(_mapper.Map<ClientPostDto>(clientViewModel));
                Clients.Add(_mapper.Map<ClientViewModel>(newClient));
            }
        });

        RxApp.MainThreadScheduler.Schedule(LoadClientAsync);
    }

    private async void LoadClientAsync()
    {
        /*Clients.Clear();
        var clients = await _apiClient.GetClientsAsync();*/
        foreach (var client in await _apiClient.GetClientsAsync())
        {
            Clients.Add(_mapper.Map<ClientViewModel>(client));
        }
    }
}