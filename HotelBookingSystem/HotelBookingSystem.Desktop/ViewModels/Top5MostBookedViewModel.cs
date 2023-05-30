using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace HotelBookingSystem.Desktop.ViewModels;
public class Top5MostBookedViewModel : ViewModelBase
{
    public ObservableCollection<HotelViewModel> Top5MostBookedResult { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private async void LoadDataAsync()
    {
        Top5MostBookedResult.Clear();
        var result = await _apiClient.Top5MostBookedAsync();
        foreach (var hotel in result)
        {
            Top5MostBookedResult.Add(_mapper.Map<HotelViewModel>(hotel));
        }
    }

    public Top5MostBookedViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }
}
