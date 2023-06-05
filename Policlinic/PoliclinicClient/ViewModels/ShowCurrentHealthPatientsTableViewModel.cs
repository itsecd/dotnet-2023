using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PoliclinicClient.ViewModels;
public class ShowCurrentHealthPatientsTableViewModel : ViewModelBase
{
    public ObservableCollection<CurrentHealthPatientsViewModel> HealthPatients { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ShowCurrentHealthPatientsTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadCurrentHealthPatientsAsync);
    }

    private async void LoadCurrentHealthPatientsAsync()
    {
        var healthPatients = await _apiClient.GetCurrentHealthAsync();

        foreach (var healthPatient in healthPatients)
        {
            HealthPatients.Add(_mapper.Map<CurrentHealthPatientsViewModel>(healthPatient));
        }
    }
}
