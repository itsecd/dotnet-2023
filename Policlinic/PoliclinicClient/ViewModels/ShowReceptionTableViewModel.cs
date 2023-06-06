using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PoliclinicClient.ViewModels;
public class ShowReceptionTableViewModel : ViewModelBase
{
    public ObservableCollection<ReceptionViewModel> Receptions { get; } = new();

    private ReceptionViewModel? _selectedReception;
    public ReceptionViewModel? SelectedReception
    {
        get => _selectedReception;
        set => this.RaiseAndSetIfChanged(ref _selectedReception, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ReceptionViewModel, ReceptionViewModel?> ShowReceptionDialog { get; }

    public ShowReceptionTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowReceptionDialog = new Interaction<ReceptionViewModel, ReceptionViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var receptionViewModel = await ShowReceptionDialog.Handle(new ReceptionViewModel());
            if (receptionViewModel != null)
            {
                var newReception = _mapper.Map<ReceptionDto>(receptionViewModel);
                await _apiClient.AddReceptionAsync(newReception);
                Receptions.Add(_mapper.Map<ReceptionViewModel>(newReception));
                Receptions.Clear();
                LoadReceptionsAsync();
            }

        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var receptionViewModel = await ShowReceptionDialog.Handle(SelectedReception!);
            if (receptionViewModel != null)
            {
                await _apiClient.UpdateReceptionAsync(SelectedReception!.Id, _mapper.Map<ReceptionDto>(receptionViewModel));
                _mapper.Map(receptionViewModel, SelectedReception);
            }

        }, this.WhenAnyValue(vm => vm.SelectedReception).Select(selectReception => selectReception != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteReceptionAsync(SelectedReception!.Id);
            Receptions.Remove(SelectedReception);

        }, this.WhenAnyValue(vm => vm.SelectedReception).Select(selectReception => selectReception != null));

        RxApp.MainThreadScheduler.Schedule(LoadReceptionsAsync);
    }

    private async void LoadReceptionsAsync()
    {
        var receptions = await _apiClient.GetReceptionsAsync();

        foreach (var reception in receptions)
        {
            Receptions.Add(_mapper.Map<ReceptionViewModel>(reception));
        }
    }
}
