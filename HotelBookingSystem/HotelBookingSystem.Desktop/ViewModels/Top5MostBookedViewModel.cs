using AutoMapper;
using HotelBookingSystem.Classes;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

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
