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
