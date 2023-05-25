using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PrivatizedBuildingViewModel> PrivatizedBuildings { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddPrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePrivatizedBuildingCommand { get; set; }

    public Interaction<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?> ShowPrivatizedBuildingDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowPrivatizedBuildingDialog = new Interaction<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?>();

        OnAddPrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedBuildingViewModel = await ShowPrivatizedBuildingDialog.Handle(new PrivatizedBuildingViewModel());
            if (privatizedBuildingViewModel != null)
            {
                var newPrivatizedBuilding = _mapper.Map<PrivatizedBuildingPostDto>(privatizedBuildingViewModel);
                await _apiClient.AddPrivatizedBuildingAsync(newPrivatizedBuilding);
                PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuildingViewModel>(newPrivatizedBuilding));
                //PrivatizedBuildings.Clear();
                //LoadPrivatizedBuildingAsync();
            }
        });

        RxApp.MainThreadScheduler.Schedule(LoadPrivatizedBuildingAsync);
    }

    private async void LoadPrivatizedBuildingAsync()
    {
        var privatizedBuildings = await _apiClient.GetPrivatizedBuildingAsync();
        foreach (var privatizedBuilding in privatizedBuildings)
        {
            PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuildingViewModel>(privatizedBuilding));
        }
    }
}
