using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace RentalService.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ClientViewModel> Clients { get; } = new();

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

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