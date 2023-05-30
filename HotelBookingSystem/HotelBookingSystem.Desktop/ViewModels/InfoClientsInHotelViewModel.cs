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
public class InfoClientsInHotelViewModel : ViewModelBase
{
    public ObservableCollection<LodgerViewModel> InfoClientsInHotelResult { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private string _nameOfHotel = string.Empty;
    public string NameOfHotel
    {
        get => _nameOfHotel;
        set => this.RaiseAndSetIfChanged(ref _nameOfHotel, value);
    }

    public ReactiveCommand<Unit, Unit> SearchByHotelCommand { get; }

    private async Task LoadDataAsync()
    {
        InfoClientsInHotelResult.Clear();
        var result = await _apiClient.InfoClientsInHotelsAsync(NameOfHotel);
        foreach (var lodger in result)
        {
            InfoClientsInHotelResult.Add(_mapper.Map<LodgerViewModel>(lodger));
        }
    }

    public InfoClientsInHotelViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        SearchByHotelCommand = ReactiveCommand.CreateFromTask(LoadDataAsync);
    }
}
