using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class ShowPrivatizedBuildingViewModel : ViewModelBase
{
    public ObservableCollection<PrivatizedBuildingViewModel> PrivatizedBuildings { get; } = new();

    private PrivatizedBuildingViewModel? _selectedPrivatizedBuilding;
    public PrivatizedBuildingViewModel? SelectedPrivatizedBuilding
    {
        get => _selectedPrivatizedBuilding;
        set => this.RaiseAndSetIfChanged(ref _selectedPrivatizedBuilding, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddPrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePrivatizedBuildingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePrivatizedBuildingCommand { get; set; }

    public Interaction<PrivatizedBuildingViewModel, PrivatizedBuildingViewModel?> ShowPrivatizedBuildingDialog { get; }

    public ShowPrivatizedBuildingViewModel()
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
                PrivatizedBuildings.Add(privatizedBuildingViewModel);
                PrivatizedBuildings.Clear();
                LoadPrivatizedBuildingAsync();
            }
        });

        OnChangePrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var privatizedBuildingViewModel = await ShowPrivatizedBuildingDialog.Handle(SelectedPrivatizedBuilding!);
            if (privatizedBuildingViewModel != null)
            {
                var newPrivatizedBuilding = _mapper.Map<PrivatizedBuildingPostDto>(privatizedBuildingViewModel);
                await _apiClient.UpdatePrivatizedBuildingAsync(SelectedPrivatizedBuilding!.Id, newPrivatizedBuilding);
                _mapper.Map(privatizedBuildingViewModel, SelectedPrivatizedBuilding);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPrivatizedBuilding).Select(selectedPrivatizedBuilding => selectedPrivatizedBuilding != null));

        OnDeletePrivatizedBuildingCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePrivatizedBuildingAsync(SelectedPrivatizedBuilding!.Id);
            PrivatizedBuildings.Remove(SelectedPrivatizedBuilding);
        }, this.WhenAnyValue(vm => vm.SelectedPrivatizedBuilding).Select(selectedPrivatizedBuilding => selectedPrivatizedBuilding != null));

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
