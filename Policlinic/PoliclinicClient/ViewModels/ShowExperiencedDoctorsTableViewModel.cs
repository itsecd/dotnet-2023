using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PoliclinicClient.ViewModels;
public class ShowExperiencedDoctorsTableViewModel : ViewModelBase
{
    public ObservableCollection<ExperiencedDoctorsViewModel> Doctors { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ShowExperiencedDoctorsTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadExperiencedDoctorsAsync);
    }

    private async void LoadExperiencedDoctorsAsync()
    {
        var doctors = await _apiClient.GetExperiencedDoctorsAsync();

        foreach (var doctor in doctors)
        {
            Doctors.Add(_mapper.Map<ExperiencedDoctorsViewModel>(doctor));
        }
    }
}
