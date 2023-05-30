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
