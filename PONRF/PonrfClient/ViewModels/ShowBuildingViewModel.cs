using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class ShowBuildingViewModel : ViewModelBase
{
    public ObservableCollection<BuildingViewModel> Buildings { get; } = new();

    private BuildingViewModel? _selectedBuilding;
    public BuildingViewModel? SelectedBuilding
    {
        get => _selectedBuilding;
        set => this.RaiseAndSetIfChanged(ref _selectedBuilding, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBuildingCommand { get; set; }

    public Interaction<BuildingViewModel, BuildingViewModel?> ShowBuildingDialog { get; }

    public ShowBuildingViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBuildingDialog = new Interaction<BuildingViewModel, BuildingViewModel?>();

        OnAddBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(new BuildingViewModel());
            if (buildingViewModel != null)
            {
                var newBuilding = _mapper.Map<BuildingPostDto>(buildingViewModel);
                await _apiClient.AddBuildingAsync(newBuilding);
                Buildings.Add(buildingViewModel);
                Buildings.Clear();
                LoadBuildingAsync();
            }
        });

        OnChangeBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var buildingViewModel = await ShowBuildingDialog.Handle(SelectedBuilding!);
            if (buildingViewModel != null)
            {
                var newBuilding = _mapper.Map<BuildingPostDto>(buildingViewModel);
                await _apiClient.UpdateBuildingAsync(SelectedBuilding!.Id, newBuilding);
                _mapper.Map(buildingViewModel, SelectedBuilding);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        OnDeleteBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBuildingAsync(SelectedBuilding!.Id);
            Buildings.Remove(SelectedBuilding);
        }, this.WhenAnyValue(vm => vm.SelectedBuilding).Select(selectedBuilding => selectedBuilding != null));

        RxApp.MainThreadScheduler.Schedule(LoadBuildingAsync);
    }

    private async void LoadBuildingAsync()
    {
        var buildings = await _apiClient.GetBuildingAsync();
        foreach (var building in buildings)
        {
            Buildings.Add(_mapper.Map<BuildingViewModel>(building));
        }
    }
}
