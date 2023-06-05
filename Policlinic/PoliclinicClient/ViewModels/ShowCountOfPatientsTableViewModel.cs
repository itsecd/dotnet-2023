using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PoliclinicClient.ViewModels;
public class ShowCountOfPatientsTableViewModel : ViewModelBase
{
    public ObservableCollection<CountOfPatientsViewModel> CountPatients { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ShowCountOfPatientsTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadCountOfPatientsAsync);
    }

    private async void LoadCountOfPatientsAsync()
    {
        var patients = await _apiClient.GetCountPatientsAsync();

        foreach (var patient in patients)
        {
            CountPatients.Add(_mapper.Map<CountOfPatientsViewModel>(patient));
        }
    }
}
