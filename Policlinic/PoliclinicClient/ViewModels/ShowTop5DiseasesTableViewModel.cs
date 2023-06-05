using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PoliclinicClient.ViewModels;
public class ShowTop5DiseasesTableViewModel : ViewModelBase
{
    public ObservableCollection<Top5DiseasesViewModel> Diseases { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ShowTop5DiseasesTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadTop5DiseasesAsync);
    }

    private async void LoadTop5DiseasesAsync()
    {
        var diseases = await _apiClient.GetTopDiseasesAsync();

        foreach (var disease in diseases)
        {
            Diseases.Add(_mapper.Map<Top5DiseasesViewModel>(disease));
        }
    }
}
