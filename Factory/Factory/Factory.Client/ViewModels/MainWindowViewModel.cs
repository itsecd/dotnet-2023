using AutoMapper;
using Microsoft.CodeAnalysis;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Factory.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<EnterpriseViewModel> Enterprises { get; } = new();

    private EnterpriseViewModel? _selectedEnterprise;
    public EnterpriseViewModel? SelectedEnterprise
    {
        get => _selectedEnterprise;
        set => this.RaiseAndSetIfChanged(ref _selectedEnterprise, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;
    
    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<EnterpriseViewModel, EnterpriseViewModel?> ShowEnterpriseDialog { get; } 
    
    public MainWindowViewModel() 
    { 
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowEnterpriseDialog = new Interaction<EnterpriseViewModel, EnterpriseViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(new EnterpriseViewModel());
            if(enterpriseViewModel != null)
            {
                var newEnterprise = _mapper.Map<EnterprisePostDto>(enterpriseViewModel);
                await _apiClient.AddEnterpriseAsync(newEnterprise);
                Enterprises.Add(enterpriseViewModel);
            }
        });


        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(SelectedEnterprise!);
            if (enterpriseViewModel != null)
            {
                var newEnterprise = _mapper.Map<EnterprisePostDto>(enterpriseViewModel);
                await _apiClient.UpdateEnterpriseAsync(SelectedEnterprise!.EnterpriseID, newEnterprise);
                _mapper.Map (enterpriseViewModel, SelectedEnterprise);
            }
        }, this.WhenAnyValue(vm => vm.SelectedEnterprise).Select(selectEnterprise => selectEnterprise != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enterpriseViewModel = await ShowEnterpriseDialog.Handle(new EnterpriseViewModel());
            if (enterpriseViewModel != null)
            {
                await _apiClient.DeleteEnterpriseAsync(SelectedEnterprise!.EnterpriseID);
                Enterprises.Remove(SelectedEnterprise);
            }
        }, this.WhenAnyValue(vm => vm.SelectedEnterprise).Select(selectEnterprise => selectEnterprise != null));

        RxApp.MainThreadScheduler.Schedule(LoadEnterprisesAsync);
    }

    private async void LoadEnterprisesAsync()
    {
        var enterprises = await _apiClient.GetEnterpriseAsync();
        foreach (var enterprise in enterprises)
        {
            Enterprises.Add(_mapper.Map<EnterpriseViewModel>(enterprise));
        }
    }
}
