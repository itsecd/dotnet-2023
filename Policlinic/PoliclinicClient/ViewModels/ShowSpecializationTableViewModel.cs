using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace PoliclinicClient.ViewModels;
public class ShowSpecializationTableViewModel : ViewModelBase
{
    public ObservableCollection<SpecializationViewModel> Specializations { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ShowSpecializationTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadSpecializationsAsync);
    }

    private async void LoadSpecializationsAsync()
    {
        var specializations = await _apiClient.GetSpecializationsAsync();

        foreach (var specialization in specializations)
        {
            Specializations.Add(_mapper.Map<SpecializationViewModel>(specialization));
        }
    }
}
