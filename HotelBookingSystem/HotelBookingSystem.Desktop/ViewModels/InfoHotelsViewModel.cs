using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace HotelBookingSystem.Desktop.ViewModels;
public class InfoHotelsViewModel : ViewModelBase
{
    public ObservableCollection<HotelViewModel> InfoHotelsResult { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private async void LoadDataAsync()
    {
        InfoHotelsResult.Clear();
        var result = await _apiClient.InfoHotelsAsync();
        foreach (var hotel in result)
        {
            InfoHotelsResult.Add(_mapper.Map<HotelViewModel>(hotel));
        }
    }

    public InfoHotelsViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadDataAsync);
    }

}
