using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace HotelBookingSystem.Desktop.ViewModels;
public class ClientsWithMostDaysViewModel : ViewModelBase
{
    public ObservableCollection<LodgerViewModel> ClientsWithMostDaysResult { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private async void LoadDataAsync()
    {
        ClientsWithMostDaysResult.Clear();
        var result = await _apiClient.ClientsWithMostDaysAsync();
        foreach (var lodger in result)
        {
            ClientsWithMostDaysResult.Add(_mapper.Map<LodgerViewModel>(lodger));
        }
    }

    public ClientsWithMostDaysViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

}
