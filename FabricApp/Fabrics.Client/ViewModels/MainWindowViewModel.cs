using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Fabrics.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public ObservableCollection<FabricViewModel> Fabrics { get; } = new();

    private FabricViewModel? _selectedFabric;

    public FabricViewModel? SelectedFabric
    {
        get => _selectedFabric;
        set => this.RaiseAndSetIfChanged(ref _selectedFabric, value);
    }

    public Interaction<FabricViewModel, FabricViewModel?> ShowFabricDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowFabricDialog = new Interaction<FabricViewModel, FabricViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var fabricViewmodel = await ShowFabricDialog.Handle(new FabricViewModel());
            if (fabricViewmodel != null)
            {
                var newFabric = await _apiClient.AddFabricAsync(_mapper.Map<FabricPostDto>(fabricViewmodel));
                Fabrics.Add(_mapper.Map<FabricViewModel>(newFabric));
            }
        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var fabricViewmodel = await ShowFabricDialog.Handle(SelectedFabric!);
            if (fabricViewmodel != null)
            {
                await _apiClient.UpdateFabricAsync(SelectedFabric!.Id, _mapper.Map<FabricPostDto>(fabricViewmodel));
                _mapper.Map(fabricViewmodel, SelectedFabric);
            }
        }, this.WhenAnyValue(vm => vm.SelectedFabric).Select(selectFabric => selectFabric != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteFabricAsync(SelectedFabric!.Id);
            Fabrics.Remove(SelectedFabric);
        }, this.WhenAnyValue(vm => vm.SelectedFabric).Select(selectFabric => selectFabric != null));

        RxApp.MainThreadScheduler.Schedule(LoadFabricAsync);
    }

    private async void LoadFabricAsync()
    {
        var fabrics = await _apiClient.GetFabricAsync();
        foreach (var fabric in fabrics)
        {
            Fabrics.Add(_mapper.Map<FabricViewModel>(fabric));
        }
    }
}
